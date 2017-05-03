using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DroneManager.Drone
{
    // Total 10 byte struct.. (no padding)
    [StructLayout(LayoutKind.Explicit, Pack=1)]
    public struct CommandPacket
    {
        [FieldOffset(0)]
        public byte commandType;
        // Flying Mode
        [FieldOffset(1)]
        public byte flyingMode;
        // Piloting
        [FieldOffset(2)]
        public sbyte roll;          // -100 ~ 100
        [FieldOffset(3)]
        public sbyte pitch;
        [FieldOffset(4)]
        public sbyte yaw;
        [FieldOffset(5)]
        public sbyte gaz;
        [FieldOffset(6)]
        public short sustainTime;    // Milliseconds
    }

    public static class CommandPacketManager
    {
        public static CommandPacket CommandPack(byte commandType, byte flyingMode,
                                        sbyte roll = -1, sbyte pitch = -1, sbyte yaw = -1, sbyte gaz = -1,
                                        short sustainTime = -1)
        {
            CommandPacket packet;
            packet.commandType = commandType;
            packet.flyingMode = flyingMode;
            packet.roll = roll;
            packet.pitch = pitch;
            packet.yaw = yaw;
            packet.gaz = gaz;
            packet.sustainTime = sustainTime;

            return packet;
        }

        public static byte[] SerializeCommand(CommandPacket packet)
        {
            int rawsize = Marshal.SizeOf(packet);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(packet, buffer, false);
            byte[] rawdata = new byte[rawsize];
            Marshal.Copy(buffer, rawdata, 0, rawsize);
            Marshal.FreeHGlobal(buffer);

            return rawdata;
        }

        public static CommandPacket? DeserializeCommand(byte[] packetBytes)
        {
            IntPtr buffer = Marshal.AllocHGlobal(packetBytes.Length);
            Marshal.Copy(packetBytes, 0, buffer, packetBytes.Length);
            object obj = Marshal.PtrToStructure(buffer, typeof(CommandPacket));
            Marshal.FreeHGlobal(buffer);
            if (Marshal.SizeOf(obj) != packetBytes.Length)
                return null;
            return (CommandPacket)obj;
        }
    }
}
