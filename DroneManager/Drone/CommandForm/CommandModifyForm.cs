using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneManager.Drone
{
    public partial class CommandModifyForm : Form
    {
        private MainForm mainForm;

        private CommandPacket packet;

        private Graphics rollPitchGraphic;
        private Graphics gazYawGraphic;
        private Pen redPen;
        private Pen bluePen;

        private bool rollPitchMouseDown;
        private Point rollPitchPoint;
        private bool gazYawMouseDown;
        private Point gazYawPoint;

        private bool isOK;

        #region CONSTRUCTORS
        public CommandModifyForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.rollPitchGraphic = this.rollPitchBox.CreateGraphics();
            this.gazYawGraphic = this.gazYawBox.CreateGraphics();
            this.redPen = new Pen(Color.Red, 2f);
            this.bluePen = new Pen(Color.Blue, 2f);
            this.rollPitchMouseDown = false;
            this.rollPitchPoint = Point.Empty;
            this.gazYawMouseDown = false;
            this.gazYawPoint = Point.Empty;
            this.isOK = false;

            this.rollPitchBox.Paint += rollPitchBox_Paint;
            this.gazYawBox.Paint += gazYawBox_Paint;
        }

        public CommandModifyForm(MainForm mainForm, DataGridViewRow dataRow)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.rollPitchGraphic = this.rollPitchBox.CreateGraphics();
            this.gazYawGraphic = this.gazYawBox.CreateGraphics();
            this.redPen = new Pen(Color.Red, 2f);
            this.bluePen = new Pen(Color.Blue, 2f);
            this.rollPitchMouseDown = false;
            this.rollPitchPoint = Point.Empty;
            this.gazYawMouseDown = false;
            this.gazYawPoint = Point.Empty;
            this.isOK = false;

            this.rollPitchBox.Paint += rollPitchBox_Paint;
            this.gazYawBox.Paint += gazYawBox_Paint;

            if (dataRow.Cells[GridViewConsts.COMMAND_TYPE].Value.Equals(CommandComboBoxConsts.TAKE_OFF))
            {
                this.packet = CommandPacketManager.CommandPack(DroneCommandType.DRONE_FLYING, DroneFlyingMode.TAKE_OFF);
                this.commandComboBox.SelectedIndex = 0;
            }
            else if(dataRow.Cells[GridViewConsts.COMMAND_TYPE].Value.Equals(CommandComboBoxConsts.LAND))
            {
                this.packet = CommandPacketManager.CommandPack(DroneCommandType.DRONE_FLYING, DroneFlyingMode.TAKE_OFF);
                this.commandComboBox.SelectedIndex = 1;
            }
            else if(dataRow.Cells[GridViewConsts.COMMAND_TYPE].Value.Equals(CommandComboBoxConsts.PILOTING))
            {
                sbyte roll = 0, pitch = 0, yaw = 0, gaz = 0;
                short sustainTime = 0;
                bool parseResult =
                    sbyte.TryParse((string)dataRow.Cells[GridViewConsts.ROLL].Value, out roll) &&
                    sbyte.TryParse((string)dataRow.Cells[GridViewConsts.PITCH].Value, out pitch) &&
                    sbyte.TryParse((string)dataRow.Cells[GridViewConsts.YAW].Value, out yaw) &&
                    sbyte.TryParse((string)dataRow.Cells[GridViewConsts.GAZ].Value, out gaz) &&
                    short.TryParse((string)dataRow.Cells[GridViewConsts.TIME].Value, out sustainTime);
                if(!parseResult)
                {
                    mainForm.ShowMessageBox("선택한 행의 데이터가 잘못되었습니다.");
                    this.Close();
                    return;
                }

                this.packet = CommandPacketManager.CommandPack(DroneCommandType.DRONE_PILOTING,
                                                                DroneFlyingMode.NONE,
                                                                roll,
                                                                pitch,
                                                                yaw,
                                                                gaz,
                                                                sustainTime);
                
                this.rollPitchPoint = new Point((int)((((float)roll + 100) / 200) * this.rollPitchBox.Size.Width), 
                                                (int)(((-(float)pitch + 100) / 200) * this.rollPitchBox.Size.Height));
                this.gazYawPoint = new Point((int)((((float)yaw + 100) / 200) * this.gazYawBox.Size.Width),
                                            (int)(((-(float)gaz + 100) / 200) * this.gazYawBox.Size.Height));

                this.rollPitchBox.Invalidate();
                this.gazYawBox.Invalidate();

                this.rollTextBox.Text = roll.ToString();
                this.pitchTextBox.Text = pitch.ToString();
                this.yawTextBox.Text = yaw.ToString();
                this.gazTextBox.Text = gaz.ToString();
                this.timeTextBox.Text = sustainTime.ToString();
            }
        }
        #endregion

        #region ROLL_PITCH_CONTROL
        private void rollPitchBox_Paint(object sender, PaintEventArgs e)
        {
            int width = this.rollPitchBox.Size.Width;
            int height = this.rollPitchBox.Size.Height;

            e.Graphics.Clear(Color.White);
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(width / 8, height / 8, 6 * width / 8, 6 * height / 8));
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(width / 4, height / 4, width / 2, height / 2));
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(3 * width / 8, 3 * height / 8, width / 4, height / 4));
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(width / 2, height / 2, 2, 2));

            if(!this.rollPitchPoint.IsEmpty)
            {
                e.Graphics.DrawLine(this.bluePen, new Point(width / 2, height / 2), this.rollPitchPoint);
            }
        }

        private void rollPitchBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.rollPitchMouseDown = true;

            this.rollPitchPoint = e.Location;
            this.packet.roll = (sbyte)((float)(e.Location.X - (float)this.rollPitchBox.Size.Width / 2)
                                        / (this.rollPitchBox.Size.Width / 2)
                                        * 100);
            this.rollTextBox.Text = this.packet.roll.ToString();

            this.packet.pitch = (sbyte)(-(float)(e.Location.Y - (float)this.rollPitchBox.Size.Height / 2)
                                        / (this.rollPitchBox.Size.Height / 2)
                                        * 100);
            this.pitchTextBox.Text = this.packet.pitch.ToString();

            this.rollPitchBox.Invalidate();
        }

        private void rollPitchBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.rollPitchMouseDown)
            {
                if (e.Location.X < 0 || e.Location.X > this.rollPitchBox.Size.Width
                    || e.Location.Y < 0 || e.Location.Y > this.rollPitchBox.Size.Height)
                    return;

                this.rollPitchPoint = e.Location;
                this.packet.roll = (sbyte)((float)(e.Location.X - (float)this.rollPitchBox.Size.Width / 2)
                                        / (this.rollPitchBox.Size.Width / 2)
                                        * 100);
                this.rollTextBox.Text = this.packet.roll.ToString();

                this.packet.pitch = (sbyte)(-(float)(e.Location.Y - (float)this.rollPitchBox.Size.Height / 2)
                                            / (this.rollPitchBox.Size.Height / 2)
                                            * 100);
                this.pitchTextBox.Text = this.packet.pitch.ToString();

                this.rollPitchBox.Invalidate();
            }
        }

        private void rollPitchBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.rollPitchMouseDown = false;
        }
        #endregion

        #region GAZ_YAW_CONTROL
        private void gazYawBox_Paint(object sender, PaintEventArgs e)
        {
            int width = this.gazYawBox.Size.Width;
            int height = this.gazYawBox.Size.Height;

            e.Graphics.Clear(Color.White);
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(width / 8, height / 8, 6 * width / 8, 6 * height / 8));
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(width / 4, height / 4, width / 2, height / 2));
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(3 * width / 8, 3 * height / 8, width / 4, height / 4));
            e.Graphics.DrawRectangle(this.redPen, new Rectangle(width / 2, height / 2, 2, 2));

            if (!this.gazYawPoint.IsEmpty)
            {
                e.Graphics.DrawLine(this.bluePen, new Point(width / 2, height / 2), this.gazYawPoint);
            }
        }

        private void gazYawBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.gazYawMouseDown = true;

            this.gazYawPoint = e.Location;
            this.packet.yaw = (sbyte)((float)(e.Location.X - (float)this.gazYawBox.Size.Width / 2)
                                        / (this.gazYawBox.Size.Width / 2)
                                        * 100);
            this.yawTextBox.Text = this.packet.yaw.ToString();

            this.packet.gaz = (sbyte)(-(float)(e.Location.Y - (float)this.gazYawBox.Size.Height / 2)
                                        / (this.gazYawBox.Size.Height / 2)
                                        * 100);
            this.gazTextBox.Text = this.packet.gaz.ToString();

            this.gazYawBox.Invalidate();
        }

        private void gazYawBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(this.gazYawMouseDown)
            {
                if (e.Location.X < 0 || e.Location.X > this.gazYawBox.Size.Width
                    || e.Location.Y < 0 || e.Location.Y > this.gazYawBox.Size.Height)
                    return;

                this.gazYawPoint = e.Location;
                this.packet.yaw = (sbyte)((float)(e.Location.X - (float)this.gazYawBox.Size.Width / 2)
                                            / (this.gazYawBox.Size.Width / 2)
                                            * 100);
                this.yawTextBox.Text = this.packet.yaw.ToString();

                this.packet.gaz = (sbyte)(-(float)(e.Location.Y - (float)this.gazYawBox.Size.Height / 2)
                                            / (this.gazYawBox.Size.Height / 2)
                                            * 100);
                this.gazTextBox.Text = this.packet.gaz.ToString();

                this.gazYawBox.Invalidate();
            }
        }

        private void gazYawBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.gazYawMouseDown = false;
        }

        #endregion

        #region TIME_CONTROL
        private void timeScrollBar_ValueChanged(object sender, EventArgs e)
        {
            this.packet.sustainTime = (short)(500 * (this.timeScrollBar.Value / 500));
            this.timeTextBox.Text = this.packet.sustainTime.ToString() + "ms";
        }
        #endregion

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.isOK = false;
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(this.commandComboBox.SelectedIndex == -1)
            {
                mainForm.ShowMessageBox("커맨드 타입을 선택하세요.");
                return;
            }

            this.isOK = true;
            this.Close();
        }

        public bool IsOK() { return this.isOK; }
        public CommandPacket GetCommand() { return this.packet; }

        private void commandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.commandComboBox.SelectedIndex == 0)
            {
                this.packet.commandType = DroneCommandType.DRONE_FLYING;
                this.packet.flyingMode = DroneFlyingMode.TAKE_OFF;
            }
            else if (this.commandComboBox.SelectedIndex == 1)
            {
                this.packet.commandType = DroneCommandType.DRONE_FLYING;
                this.packet.flyingMode = DroneFlyingMode.LAND;
            }
            else if (this.commandComboBox.SelectedIndex == 2)
            {
                this.packet.commandType = DroneCommandType.DRONE_PILOTING;
            }
        }
    }
}
