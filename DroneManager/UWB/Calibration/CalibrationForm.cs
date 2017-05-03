using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DroneManager.Drone;
using DroneManager.UWB.Calibration;

namespace DroneManager
{
    public partial class CalibrationForm : Form
    {
        private MainForm parent;
        private Dictionary<int, BebopDrone> droneList;
        private List<int> powers;
        private List<int> times;
        
        public CalibrationForm(MainForm parent, Dictionary<int, BebopDrone> droneList)
        {
            InitializeComponent();
            this.parent = parent;
            this.droneList = droneList;
            foreach(int key in droneList.Keys)
                this.calibrationDroneComboBox.Items.Add(key.ToString());
            this.powers = new List<int>();
            this.times = new List<int>();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calibrationBtn_Click(object sender, EventArgs e)
        {
            if (calibrationDroneComboBox.SelectedIndex < 0)
            {
                parent.ShowMessageBox("Please select drone");
                return;
            }

            int index = -1;
            try
            {
                index = int.Parse((string)calibrationDroneComboBox.SelectedItem);
            }
            catch (FormatException ex)
            {
                parent.ShowMessageBox("Id가 숫자가 아닙니다.");
                return;
            }
            droneList[index].CheckConnection();
            droneList[index].AddACKCheckEvent(
                delegate () {
                    System.Threading.Thread thread = new System.Threading.Thread(
                        delegate ()
                        {
                            CalibrationInfo cInfo = CalibrationManager.Calibrate(parent,
                                                        droneList[index],
                                                        parent.GetUWBManager(),
                                                        droneList[index].GetTagID(),
                                                        "temp",
                                                        powers.ToArray(),
                                                        times.ToArray());
                            CalibrationList.AddCalibrationData(parent, "temp", cInfo);
                        });
                    thread.Start();
                }, 3000, "Check your device is connected to the drone.");

            this.Close();
        }

        #region POWER_LIST
        private int GetPowerFromTextBox()
        {
            int power;
            if (!int.TryParse(this.powerTextBox.Text, out power))
            {
                parent.ShowMessageBox("Write correct power");
                return 0;
            }

            if (power > 100 || power < 0)
            {
                parent.ShowMessageBox("Power must be 0 ~ 100");
                return 0;
            }

            return power;
        }

        private void addPowerBtn_Click(object sender, EventArgs e)
        {
            int power = this.GetPowerFromTextBox();
            if (power == 0)
                return;

            if (powers.Contains(power) == true)
                return;

            powerListBox.Items.Add(power);
            powers.Add(power);
        }

        private void powerRemoveBtn_Click(object sender, EventArgs e)
        {
            if (powerListBox.SelectedIndex == -1)
            {
                parent.ShowMessageBox("Select power");
                return;
            }
            else
            {
                powers.RemoveAt(powerListBox.SelectedIndex);
                powerListBox.Items.RemoveAt(powerListBox.SelectedIndex);
            }
        }
        #endregion

        #region TIME_LIST
        private int GetTimeFromTextBox()
        {
            int time;
            if (!int.TryParse(this.timeTextBox.Text, out time))
            {
                parent.ShowMessageBox("Write correct time");
                return 0;
            }

            if (time <= 0 || time > 30000)
            {
                parent.ShowMessageBox("Time must be 0 ~ 30000 ms");
                return 0;
            }

            return time;
        }

        private void addTimeBtn_Click(object sender, EventArgs e)
        {
            int time = this.GetTimeFromTextBox();
            if (time == 0)
                return;

            if (times.Contains(time) == true)
                return;

            timeListBox.Items.Add(time);
            powers.Add(time);
        }

        private void timeRemoveBtn_Click(object sender, EventArgs e)
        {
            if (timeListBox.SelectedIndex == -1)
            {
                parent.ShowMessageBox("Select time");
                return;
            }
            else
            {
                times.RemoveAt(timeListBox.SelectedIndex);
                timeListBox.Items.RemoveAt(timeListBox.SelectedIndex);
            }
        }
        #endregion
    }
}
