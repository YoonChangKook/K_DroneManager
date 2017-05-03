using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using DroneManager.BluetoothModule;
using DroneManager.Drone;
using DroneManager.UWB;
using DroneManager.UWB.Calibration;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DroneManager
{
    public partial class MainForm : Form
    {
        private readonly object controlLocker;
        private bool isGLControlLoad;
        private BluetoothServer server;
        private Dictionary<int, BebopDrone> droneList;
        private UWBManager uwbManager;

        public MainForm()
        {
            InitializeComponent();
            controlLocker = new object();
            isGLControlLoad = false;
            server = new BluetoothServer(this);
            droneList = new Dictionary<int, BebopDrone>();
            uwbManager = new UWBManager(this);
        }

        public void UpdateLog(string text)
        {
            Func<int> del = delegate()
            {
                lock (controlLocker)
                {
                    LogBox.AppendText(text + System.Environment.NewLine);
                }
                return 0;
            };
            Invoke(del);
        }

        public void ShowMessageBox(string text)
        {
            this.Invoke(new Action(() => { MessageBox.Show(this, text); }));
        }

        public void ReceiveDroneInfo(int clientID, byte[] packetBytes)
        {
            //if (droneList[clientID].IsGetSpec() == false)
            //    droneList[clientID].TakeDroneAPName(packetBytes);
            //else
                droneList[clientID].TakeInfoPacketBytes(packetBytes);
        }

        private void serverStartBtn_Click(object sender, EventArgs e)
        {
            server.ServerStart();
            if (server.GetServerStarted() == true)
                serverStartBtn.Text = "Server Close";
            else
                serverStartBtn.Text = "Server Start";
        }

        public void ConnectDrone(int id)
        {
            droneList.Add(id, new BebopDrone(id, this, this.server));
            // Debug
            //if (id == 0)
            ConnectTagToDrone(id, 1);

            AddDroneToComboBox(id.ToString());
        }
        public void DisconnectDrone(int id)
        {
            droneList.Remove(id);

            RemoveDroneInComboBox(id.ToString());
        }

        public void ConnectTagToDrone(int clientId, int tagId)
        {
            if (droneList.ContainsKey(clientId) == true)
                droneList[clientId].SetDroneTag(tagId);
            else
                ShowMessageBox("Client" + clientId + " is doesn't exist.");
        }

        #region CONTROL_FUNCTIONS
        #region ANALOG
        private void takeOffBtn_Click(object sender, EventArgs e)
        {
            if (clientListCombo.SelectedIndex == 0)
            {
                int[] ids = server.GetClientIds();
                foreach (int id in ids)
                    droneList[id].TakeOff();
            }
            else if(clientListCombo.SelectedIndex > 0)
            {
                int id = -1;
                int.TryParse((string)clientListCombo.SelectedItem, out id);
                if (id != -1)
                    droneList[id].TakeOff();
                else
                    ShowMessageBox("drone " + (string)clientListCombo.SelectedItem + "is doesn't exist.");
            }
        }

        private void landBtn_Click(object sender, EventArgs e)
        {
            if (clientListCombo.SelectedIndex == 0)
            {
                int[] ids = server.GetClientIds();
                foreach (int id in ids)
                    droneList[id].Land();
            }
            else if (clientListCombo.SelectedIndex > 0)
            {
                int id = -1;
                int.TryParse((string)clientListCombo.SelectedItem, out id);
                if (id != -1)
                    droneList[id].Land();
                else
                    ShowMessageBox("drone " + (string)clientListCombo.SelectedItem + "is doesn't exist.");
            }
        }

        private void pcmdBtn_Click(object sender, EventArgs e)
        {
            sbyte roll = 0, pitch = 0, yaw = 0, gaz = 0;
            short sustainTime = 0;
            try{
                roll = sbyte.Parse(rollTextBox.Text);
                pitch = sbyte.Parse(pitchTextBox.Text);
                yaw = sbyte.Parse(yawTextBox.Text);
                gaz = sbyte.Parse(gazTextBox.Text);
                sustainTime = short.Parse(timeTextBox.Text);
            } catch(FormatException ex) {
                MessageBox.Show("정확한 숫자만 입력해주세요");
                return;
            }

            if (clientListCombo.SelectedIndex == 0)
            {
                int[] ids = server.GetClientIds();
                foreach (int id in ids)
                    droneList[id].PCMD_Move(roll, pitch, yaw, gaz, sustainTime);
            }
            else if (clientListCombo.SelectedIndex > 0)
            {
                int id = -1;
                int.TryParse((string)clientListCombo.SelectedItem, out id);
                if (id != -1)
                    droneList[id].PCMD_Move(roll, pitch, yaw, gaz, sustainTime);
                else
                    ShowMessageBox("drone " + (string)clientListCombo.SelectedItem + "is doesn't exist.");
            }
        }

        private void pcmdKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }
        #endregion

        #region SCHEDULE
        private void scheduleClientListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexStr = (string)scheduleClientListCombo.SelectedItem;
            if (indexStr.CompareTo("ALL") == 0)
                return;

            int index = -1;
            if (!int.TryParse(indexStr, out index))
            {
                this.ShowMessageBox("Clinet id is wrong");
                return;
            }

            this.scheduleGridView.Rows.Clear();
            foreach (CommandPacket packet in this.droneList[index].GetScheduleList())
            {
                DataGridViewRow tempRow = scheduleGridView.Rows[scheduleGridView.Rows.Add()];
                if (packet.commandType == DroneCommandType.DRONE_FLYING)
                {
                    if (packet.flyingMode == DroneFlyingMode.TAKE_OFF)
                        tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.TAKE_OFF;
                    else if (packet.flyingMode == DroneFlyingMode.LAND)
                        tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.LAND;
                }
                else if(packet.commandType == DroneCommandType.DRONE_PILOTING)
                {
                    tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.PILOTING;
                    tempRow.Cells[GridViewConsts.ROLL].Value = packet.roll.ToString();
                    tempRow.Cells[GridViewConsts.PITCH].Value = packet.pitch.ToString();
                    tempRow.Cells[GridViewConsts.YAW].Value = packet.yaw.ToString();
                    tempRow.Cells[GridViewConsts.GAZ].Value = packet.gaz.ToString();
                    tempRow.Cells[GridViewConsts.TIME].Value = packet.sustainTime.ToString();
                }
            }
        }

        private void scheduleAddBtn_Click(object sender, EventArgs e)
        {
            int index = this.scheduleClientListCombo.SelectedIndex;
            if (index == -1)
            {
                this.ShowMessageBox("Select drone first");
                return;
            }

            string indexStr = (string)scheduleClientListCombo.SelectedItem;

            CommandModifyForm commandModify = new CommandModifyForm(this);
            commandModify.ShowDialog();

            if (commandModify.IsOK() == false)
                return;

            CommandPacket result = commandModify.GetCommand();
            if (indexStr.CompareTo("ALL") == 0)
            {
                foreach (BebopDrone drone in droneList.Values)
                    drone.AddSchedule(result);
                return;
            }
            else
            {
                int clientID = -1;
                if (!int.TryParse(indexStr, out clientID))
                {
                    this.ShowMessageBox("Clinet id is wrong");
                    return;
                }
                this.droneList[clientID].AddSchedule(result);

                DataGridViewRow tempRow = scheduleGridView.Rows[scheduleGridView.Rows.Add()];
                if (result.commandType == DroneCommandType.DRONE_FLYING)
                {
                    if (result.flyingMode == DroneFlyingMode.TAKE_OFF)
                        tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.TAKE_OFF;
                    else if (result.flyingMode == DroneFlyingMode.LAND)
                        tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.LAND;
                }
                else if (result.commandType == DroneCommandType.DRONE_PILOTING)
                {
                    tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.PILOTING;
                    tempRow.Cells[GridViewConsts.ROLL].Value = result.roll.ToString();
                    tempRow.Cells[GridViewConsts.PITCH].Value = result.pitch.ToString();
                    tempRow.Cells[GridViewConsts.YAW].Value = result.yaw.ToString();
                    tempRow.Cells[GridViewConsts.GAZ].Value = result.gaz.ToString();
                    tempRow.Cells[GridViewConsts.TIME].Value = result.sustainTime.ToString();
                }
            }
        }

        private void scheduleModifyBtn_Click(object sender, EventArgs e)
        {
            int index = this.scheduleClientListCombo.SelectedIndex;
            if (index == -1)
            {
                this.ShowMessageBox("Select drone first");
                return;
            }

            string indexStr = (string)scheduleClientListCombo.SelectedItem;
            if (indexStr.CompareTo("ALL") == 0)
                return;

            int clientID = -1;
            if (!int.TryParse(indexStr, out clientID))
            {
                this.ShowMessageBox("Clinet id is wrong");
                return;
            }

            if (this.scheduleGridView.CurrentCell != null)
            {
                int rowIndex = this.scheduleGridView.CurrentCell.RowIndex;
                DataGridViewRow tempRow = this.scheduleGridView.Rows[rowIndex];

                CommandModifyForm commandModify = new CommandModifyForm(this, tempRow);
                commandModify.ShowDialog();

                if (commandModify.IsOK() == false)
                    return;

                CommandPacket result = commandModify.GetCommand();
                this.droneList[clientID].ModifySchedule(rowIndex, result);
                if (result.commandType == DroneCommandType.DRONE_FLYING)
                {
                    if (result.flyingMode == DroneFlyingMode.TAKE_OFF)
                        tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.TAKE_OFF;
                    else if (result.flyingMode == DroneFlyingMode.LAND)
                        tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.LAND;
                }
                else if (result.commandType == DroneCommandType.DRONE_PILOTING)
                {
                    tempRow.Cells[GridViewConsts.COMMAND_TYPE].Value = CommandModifyForm.CommandComboBoxConsts.PILOTING;
                    tempRow.Cells[GridViewConsts.ROLL].Value = result.roll.ToString();
                    tempRow.Cells[GridViewConsts.PITCH].Value = result.pitch.ToString();
                    tempRow.Cells[GridViewConsts.YAW].Value = result.yaw.ToString();
                    tempRow.Cells[GridViewConsts.GAZ].Value = result.gaz.ToString();
                    tempRow.Cells[GridViewConsts.TIME].Value = result.sustainTime.ToString();
                }
            }
            else
            {
                this.ShowMessageBox("수정할 행을 선택해주세요.");
                return;
            }
        }

        private void scheduleRemoveBtn_Click(object sender, EventArgs e)
        {
            int index = this.scheduleClientListCombo.SelectedIndex;
            if (index == -1)
            {
                this.ShowMessageBox("Select drone first");
                return;
            }

            string indexStr = (string)scheduleClientListCombo.SelectedItem;
            if (indexStr.CompareTo("ALL") == 0)
                return;

            int clientID = -1;
            if (!int.TryParse(indexStr, out clientID))
            {
                this.ShowMessageBox("Clinet id is wrong");
                return;
            }

            foreach (DataGridViewRow item in this.scheduleGridView.SelectedRows)
            {
                this.scheduleGridView.Rows.RemoveAt(item.Index);
                this.droneList[clientID].RemoveSchedule(item.Index);
            }
        }

        private void scheduleClearBtn_Click(object sender, EventArgs e)
        {
            int index = this.scheduleClientListCombo.SelectedIndex;
            if (index == -1)
            {
                this.ShowMessageBox("Select drone first");
                return;
            }

            string indexStr = (string)scheduleClientListCombo.SelectedItem;
            if (indexStr.CompareTo("ALL") == 0)
            {
                foreach (BebopDrone drone in droneList.Values)
                    drone.ClearSchedule();
                return;
            }
            else
            {
                int clientID = -1;
                if (!int.TryParse(indexStr, out clientID))
                {
                    this.ShowMessageBox("Clinet id is wrong");
                    return;
                }

                this.droneList[clientID].ClearSchedule();
                this.scheduleGridView.Rows.Clear();
            }
        }

        private void scheduleBtn_Click_1(object sender, EventArgs e)
        {
            int index = this.scheduleClientListCombo.SelectedIndex;
            if (index == -1)
            {
                this.ShowMessageBox("Select drone first");
                return;
            }

            string indexStr = (string)scheduleClientListCombo.SelectedItem;
            if (indexStr.CompareTo("ALL") == 0)
            {
                foreach (BebopDrone drone in droneList.Values)
                    drone.Schedule();
                return;
            }
            else
            {
                int clientID = -1;
                if (!int.TryParse(indexStr, out clientID))
                {
                    this.ShowMessageBox("Clinet id is wrong");
                    return;
                }

                if (droneList.ContainsKey(clientID) == false)
                {
                    this.ShowMessageBox("There is no client id in drone list.");
                    return;
                }

                droneList[clientID].Schedule();
                return;
            }
        }
        #endregion
        #endregion

        #region DRONE_LIST_FUNCTIONS
        private void deviceListBtn_Click(object sender, EventArgs e)
        {
            DeviceListForm deviceListForm = new DeviceListForm(this);
            deviceListForm.ShowDialog();
        }
        #endregion

        #region UWB_CONTROL_FUNCTION
        private void serialPortBtn_Click(object sender, EventArgs e)
        {
            SerialPortForm serialPortForm = new SerialPortForm(this);
            serialPortForm.ShowDialog();
        }

        private void uwbGLControl_Load(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, uwbGLControl.Width, uwbGLControl.Height);
            GL.Enable(EnableCap.DepthTest);

            //Set Lighting
            float[] mat_ambient = { 0.1f, 0.1f, 0.1f, 1.0f };
            float[] mat_diffuse = { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] mat_shininess = { 30.0f };
            float[] light_position = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] light_ambient = { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light_diffuse = { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light_specular = { 0.7f, 0.7f, 0.7f, 1.0f };

            GL.ClearColor(Color.CornflowerBlue);
            GL.ShadeModel(ShadingModel.Smooth);

            GL.Material(MaterialFace.Front, MaterialParameter.Ambient, mat_ambient);
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, mat_diffuse);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);
            GL.Light(LightName.Light0, LightParameter.Position, light_position);
            GL.Light(LightName.Light0, LightParameter.Ambient, light_ambient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, light_diffuse);
            GL.Light(LightName.Light0, LightParameter.Specular, light_specular);
            GL.Light(LightName.Light0, LightParameter.ConstantAttenuation, 2.0f);
            GL.Light(LightName.Light0, LightParameter.LinearAttenuation, 1.0f);
            GL.Light(LightName.Light0, LightParameter.QuadraticAttenuation, 0.5f);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.ColorMaterial);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);

            isGLControlLoad = true;
        }

        private void uwbGLControl_Paint(object sender, PaintEventArgs e)
        {
            if (isGLControlLoad == false)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit |
                     ClearBufferMask.DepthBufferBit |
                     ClearBufferMask.StencilBufferBit);
            GL.ClearColor(Color.CornflowerBlue);

            Matrix4 modelview = Matrix4.LookAt(10f, 10f, 10f, 0f, 0f, 0f, 0.0f, 1.0f, 0.0f);
            var aspect_ratio = uwbGLControl.Width / (float)uwbGLControl.Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, aspect_ratio, 1f, 256f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            GL.Enable(EnableCap.Light0);
            

            int[] keys = uwbManager.GetAnchorKeys();
            foreach (int key in keys)
            {
                UWB.Vector3 pos = uwbManager.GetAnchorPos(key);
                GL.PushMatrix();
                GL.Translate(pos.x, pos.y, pos.z);
                GL.Scale(0.6, 0.6, 0.6);
                DrawSphere();
                GL.PopMatrix();
            }

            keys = uwbManager.GetTagKeys();
            foreach (BebopDrone drone in droneList.Values)
            {
                int key = drone.GetTagID();
                if (key == -1 || keys.Contains(key) == false)
                    continue;

                UWB.Vector3 pos = uwbManager.GetTagPos(key);
                GL.PushMatrix();
                GL.Translate(pos.x, pos.y, pos.z);
                GL.Scale(0.3, 0.3, 0.3);
                DrawSphere();
                GL.PopMatrix();
            }

            uwbGLControl.SwapBuffers();
        }
        private void DrawSphere()
        {
            for (int angle1 = -90; angle1 < 90; angle1 += 5)
            {
                GL.Begin(PrimitiveType.QuadStrip);
                for (int angle2 = 0; angle2 <= 360; angle2 += 2 * 5)
                {
                    GL.Color4(Color.White);
                    VertexWithAngle(angle1, angle2);
                    VertexWithAngle(angle1, angle2 + 5);
                }
                GL.End();
            }
        }
        private void VertexWithAngle(int angle1, int angle2)
        {
            double x = Math.Sin(angle2) * Math.Cos(angle1);
            double y = Math.Cos(angle2) * Math.Cos(angle1);
            double z = Math.Sin(angle1);
            GL.Vertex3(x, y, z);
        }

        protected override void WndProc(ref Message m)
        {
            UInt32 WM_DEVICECHANGE = 0x0219;
            UInt32 DBT_DEVTUP_VOLUME = 0x02;
            UInt32 DBT_DEVTUP_PORT = 0x03;
            UInt32 DBT_DEVICEARRIVAL = 0x8000;
            UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))  //디바이스 연결 해제
            {
                int devType = Marshal.ReadInt32(m.LParam, 4);
                if (devType == DBT_DEVTUP_VOLUME || devType == DBT_DEVTUP_PORT)
                {
                    uwbManager.SerialPortClose();
                }
            }

            base.WndProc(ref m);
        }

        public void UpdateUWBLog(string str)
        {
            Func<int> del = delegate()
            {
                lock (controlLocker)
                {
                    uwbInfoTextBox.Text = str;
                }
                return 0;
            };
            Invoke(del);
        }

        public void UpdateUWBGL()
        {
            Func<int> del = delegate()
            {
                lock (controlLocker)
                {
                    uwbGLControl.Invalidate();
                }
                return 0;
            };
            Invoke(del);
        }
        #endregion

        #region CALIBRATION_FUNCTIONS
        private void calibrationBtn_Click(object sender, EventArgs e)
        {
            CalibrationForm calibrationForm = new CalibrationForm(this, this.droneList);
            calibrationForm.ShowDialog();
        }

        public void UpdateCalibrationLog(string text)
        {
            Func<int> del = delegate()
            {
                lock (controlLocker)
                {
                    calibrationLogBox.AppendText(text + System.Environment.NewLine);
                }
                return 0;
            };
            Invoke(del);
        }

        public void AddDroneToComboBox(string id)
        {
            Func<int> del = delegate()
            {
                lock (controlLocker)
                {
                    if (!clientListCombo.Items.Contains(id))
                        clientListCombo.Items.Add(id);
                    if (!scheduleClientListCombo.Items.Contains(id))
                        scheduleClientListCombo.Items.Add(id);
                }
                return 0;
            };
            Invoke(del);
        }
        public void RemoveDroneInComboBox(string id)
        {
            Func<int> del = delegate()
            {
                lock (controlLocker)
                {
                    if (clientListCombo.Items.Contains(id))
                        clientListCombo.Items.Remove(id);
                    if (scheduleClientListCombo.Items.Contains(id))
                        scheduleClientListCombo.Items.Remove(id);
                }
                return 0;
            };
            Invoke(del);
        }
        #endregion

        #region GET_SET_FUNCTIONS
        public UWBManager GetUWBManager() { return this.uwbManager; }
        #endregion

        private void debugBtn_Click(object sender, EventArgs e)
        {
            CommandPacket packet = CommandPacketManager.CommandPack(0, 0);
            byte[] temp = CommandPacketManager.SerializeCommand(packet);
            UpdateLog("Length: " + temp.Length.ToString());
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            int[] ids = server.GetClientIds();
            if (ids.Length != 2)
            {
                ShowMessageBox("Connected drone count have to be 2");
                return;
            }

            foreach(int id in ids)
                droneList[id].TakeOff();

            System.Threading.Timer timer = new System.Threading.Timer(
                    delegate(object state)
                    {
                        droneList[ids[0]].PCMD_Move(0, 100, 0, 0, 500);
                        droneList[ids[1]].PCMD_Move(0, 0, 100, 0, 1500);
                    }, null, 5000, System.Threading.Timeout.Infinite);
            
            timer = new System.Threading.Timer(
                    delegate(object state)
                    {
                        droneList[ids[0]].PCMD_Move(0, -100, 0, 0, 500);
                        droneList[ids[1]].PCMD_Move(0, 0, -100, 0, 1500);
                    }, null, 8000, System.Threading.Timeout.Infinite);

            timer = new System.Threading.Timer(
                    delegate(object state)
                    {
                        droneList[ids[0]].PCMD_Move(0, -100, 0, 0, 500);
                        droneList[ids[1]].PCMD_Move(0, 0, -100, 0, 1500);
                    }, null, 11000, System.Threading.Timeout.Infinite);

            timer = new System.Threading.Timer(
                    delegate(object state)
                    {
                        droneList[ids[0]].PCMD_Move(0, 100, 0, 0, 500);
                        droneList[ids[1]].PCMD_Move(0, 0, 100, 0, 1500);
                    }, null, 14000, System.Threading.Timeout.Infinite);

            timer = new System.Threading.Timer(
                    delegate(object state)
                    {
                        foreach (int id in ids)
                            droneList[id].Land();
                    }, null, 18000, System.Threading.Timeout.Infinite);
        }
    }
}
