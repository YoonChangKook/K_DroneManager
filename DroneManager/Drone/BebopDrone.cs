using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DroneManager.BluetoothModule;

namespace DroneManager.Drone
{
    public class BebopDrone
    {
        public static readonly int AIR_BREAK_DIVIDE = 5;
        public delegate void ACKDelegate();
        private ACKDelegate ackCheckEvent;
        public delegate void TimeOutDelegate();
        private TimeOutDelegate timeOutEvent;
        // Members
        private bool isGetSpec;
        private int id;
        private int tagId;
        private MainForm mainForm;
        private sbyte battery;
        private byte flyingState;
        // Command server
        private BluetoothServer server;
        // DroneInfoPacket buffer
        private byte[] infoPacketBuffer;
        private int bufferStartIndex;
        // Schedule Queue
        private List<CommandPacket> commandSchedule;
        private static readonly int SCHEDULE_WAIT_TERM = 1500;
        private int scheduleIndex;

        // Constructors
        public BebopDrone(int id, MainForm mainForm, BluetoothServer server)
        {
            this.isGetSpec = false;
            this.id = id;
            this.tagId = -1;
            this.mainForm = mainForm;
            this.server = server;
            this.infoPacketBuffer = new byte[Marshal.SizeOf(typeof(DroneInfoPacket))];
            this.bufferStartIndex = 0;
            this.commandSchedule = new List<CommandPacket>();
            this.scheduleIndex = 0;
        }

        // Methods
        public void SetDroneTag(int tagId) { this.tagId = tagId; }
        public void AddACKCheckEvent(ACKDelegate check_delegate,
            int timeOut = -1,
            string timeOutMsg = "",
            TimeOutDelegate timeout_delegate = null)
        {
            if (timeOut > 0)
            {
                System.Threading.Timer timer = new System.Threading.Timer(
                    delegate(object state)
                    {
                        if (timeOutEvent != null)
                            timeOutEvent.Invoke();
                        RemoveACKCheckEvent();
                        //mainForm.ShowMessageBox(timeOutMsg);
                    }, null, timeOut, System.Threading.Timeout.Infinite);
                ackCheckEvent += delegate() { timer.Dispose(); };
            }
            ackCheckEvent += check_delegate;
            timeOutEvent += timeout_delegate;
        }
        public void RemoveACKCheckEvent()
        {
            ackCheckEvent = null;
            timeOutEvent = null;
        }

        #region PACKET_FUNCTION
        public void TakeDroneInfo(byte[] infoBytes)
        {
            string deviceId = Encoding.Default.GetString(infoBytes);
            DroneInfo dInfo = DroneList.GetDroneInfo(mainForm, deviceId);
            string ap = dInfo.GetAPName();
            if (ap.Length == 0)
                server.DeleteClient(this.id);

            server.WriteData(this.id, Encoding.UTF8.GetBytes(ap));
            this.isGetSpec = true;
        }
        public void TakeInfoPacketBytes(byte[] packetBytes)
        {
            int readByte = 0;
            while (readByte < packetBytes.Length)
            {
                if (packetBytes.Length - readByte >= infoPacketBuffer.Length - bufferStartIndex)
                {
                    Buffer.BlockCopy(packetBytes,
                        readByte,
                        infoPacketBuffer,
                        bufferStartIndex,
                        infoPacketBuffer.Length - bufferStartIndex);
                    readByte += infoPacketBuffer.Length - bufferStartIndex;
                    bufferStartIndex = 0;

                    // Make DroneInfoPacket
                    DroneInfoPacket? packet = DroneInfoPacketManager.DeserializeDroneInfo(infoPacketBuffer);
                    if (packet != null)
                    {
                        PacketHandle(packet.Value);
                    }
                }
                else
                {
                    Buffer.BlockCopy(packetBytes,
                        readByte,
                        infoPacketBuffer,
                        bufferStartIndex,
                        packetBytes.Length - readByte);
                    bufferStartIndex += packetBytes.Length - readByte;
                    readByte += packetBytes.Length - readByte;
                }
            }
        }
        private void PacketHandle(DroneInfoPacket packet)
        {
            // Do something with drone info..
            if (packet.flyingState == DroneFlyingState.ACK)
            {
                if(ackCheckEvent != null)
                    ackCheckEvent.Invoke();
                RemoveACKCheckEvent();
                return;
            }
            if (packet.battery >= 0 && packet.battery <= 100)
                BatteryChange(packet.battery);
            if (packet.flyingState != DroneFlyingState.NONE)
                FlyingStateChange(packet.flyingState);
        }
        #endregion

        #region STATE_CHANGE_METHOD
        private void BatteryChange(sbyte battery)
        {
            mainForm.UpdateLog("Client" + id.ToString() + " Battery: " + battery.ToString());
            this.battery = battery;
        }
        private void FlyingStateChange(byte flyingState)
        {
            if (flyingState == DroneFlyingState.HOVERING)
                mainForm.UpdateLog("Client" + id.ToString() +
                    " Flying state changed to : Hovering");
            else if(flyingState == DroneFlyingState.FLYING)
                mainForm.UpdateLog("Client" + id.ToString() +
                    " Flying state changed to : Flying");
            else if (flyingState == DroneFlyingState.LANDED)
                mainForm.UpdateLog("Client" + id.ToString() +
                    " Flying state changed to : Landed");
            this.flyingState = flyingState;
        }
        #endregion

        #region GET_METHODS
        public bool IsGetSpec() { return this.isGetSpec; }
        public sbyte GetBattery() { return this.battery; }
        public byte GetFlyingState() { return this.flyingState; }
        public int GetTagID() { return this.tagId; }
        #endregion

        #region COMMAND_METHODS
        // Device have to return ACK if device connect to drone 
        public void CheckConnection()
        {
            CommandPacket packet =
                CommandPacketManager.CommandPack(DroneCommandType.ACK,
                                                DroneFlyingMode.NONE);
            byte[] packetBytes = CommandPacketManager.SerializeCommand(packet);

            server.WriteData(id, packetBytes);
        }
        // Device have to return ACK if device command to drone successfully
        public void TakeOff()
        {
            CommandPacket packet =
                CommandPacketManager.CommandPack(DroneCommandType.DRONE_FLYING,
                                                DroneFlyingMode.TAKE_OFF);
            byte[] packetBytes = CommandPacketManager.SerializeCommand(packet);

            AddACKCheckEvent(delegate() { mainForm.UpdateLog("Take off success"); },
                            2000,
                            "Take off time out.");
            server.WriteData(id, packetBytes);
        }
        // Device have to return ACK if device command to drone successfully
        public void Land()
        {
            CommandPacket packet =
                CommandPacketManager.CommandPack(DroneCommandType.DRONE_FLYING,
                                                DroneFlyingMode.LAND);
            byte[] packetBytes = CommandPacketManager.SerializeCommand(packet);

            AddACKCheckEvent(delegate() { mainForm.UpdateLog("Land success"); },
                            2000,
                            "Land time out.");
            server.WriteData(id, packetBytes);
        }
        // Device have to return ACK if drone move done successfully
        public void PCMD_Move(sbyte roll, sbyte pitch, sbyte yaw, sbyte gaz, short time)
        {
            // Move
            CommandPacket packet =
                CommandPacketManager.CommandPack(DroneCommandType.DRONE_PILOTING,
                                                DroneFlyingMode.NONE,
                                                roll, pitch, yaw, gaz, time);
            byte[] packetBytes = CommandPacketManager.SerializeCommand(packet);
            byte temp = packetBytes[packetBytes.Length - 1];
            packetBytes[packetBytes.Length - 1] = packetBytes[packetBytes.Length - 2];
            packetBytes[packetBytes.Length - 2] = temp;

            AddACKCheckEvent(delegate() { mainForm.UpdateLog("PCMD move Success"); },
                            2000,
                            "PCMD move time out.");
            server.WriteData(id, packetBytes);
        }
        #endregion

        #region SCHEDULE_METHODS
        public void AddSchedule(CommandPacket command)
        {
            commandSchedule.Add(command);
        }

        public void ModifySchedule(int index, CommandPacket command)
        {
            commandSchedule[index] = command;
        }
        
        public void RemoveSchedule(int index)
        {
            commandSchedule.RemoveAt(index);
        }

        public void ClearSchedule()
        {
            commandSchedule.Clear();
        }

        public void Schedule(int index = 0, int delay = 0)
        {
            System.Threading.Timer timer = new System.Threading.Timer(
                        delegate (object state)
                        {
                            if (this.commandSchedule.Count <= index)
                                return;

                            int scheduleTime = 0;
                            if (commandSchedule[index].commandType == DroneCommandType.DRONE_FLYING)
                                scheduleTime = 5000;
                            else if (commandSchedule[index].commandType == DroneCommandType.DRONE_PILOTING)
                                scheduleTime = commandSchedule[index].sustainTime;

                            byte[] packetBytes = CommandPacketManager.SerializeCommand(this.commandSchedule[index]);
                            byte temp = packetBytes[packetBytes.Length - 1];
                            packetBytes[packetBytes.Length - 1] = packetBytes[packetBytes.Length - 2];
                            packetBytes[packetBytes.Length - 2] = temp;

                            AddACKCheckEvent(delegate()
                                            {
                                                mainForm.UpdateLog("schedule" + index.ToString() + " success");
                                                Schedule(++this.scheduleIndex, scheduleTime + BebopDrone.SCHEDULE_WAIT_TERM);
                                            },
                                            2000,
                                            "Schedule time out.");
                            server.WriteData(id, packetBytes);
                        }, null, delay, System.Threading.Timeout.Infinite);
        }

        public CommandPacket[] GetScheduleList()
        {
            return this.commandSchedule.ToArray();
        }
        #endregion
    }
}
