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

namespace DroneManager
{
    public partial class RemoveDeviceForm : Form
    {
        private MainForm parent;
        
        public RemoveDeviceForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            string[] devices = DroneList.GetAllDeviceName(parent);
            foreach(string deviceName in devices)
                this.deviceComboBox.Items.Add(deviceName);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if(deviceComboBox.SelectedIndex == -1)
            {
                this.parent.ShowMessageBox("삭제할 디바이스를 선택해주세요.");
                return;
            }
            else
            {
                DroneList.RemoveDroneInfo(this.parent, (string)deviceComboBox.SelectedItem);
                this.Close();
                return;
            }
        }
    }
}
