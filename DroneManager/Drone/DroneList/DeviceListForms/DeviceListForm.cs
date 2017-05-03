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
    public partial class DeviceListForm : Form
    {
        private MainForm parent;

        public DeviceListForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addDeviceBtn_Click(object sender, EventArgs e)
        {
            AddDeviceForm form = new AddDeviceForm(parent);
            form.ShowDialog();
        }

        private void removeDeviceBtn_Click(object sender, EventArgs e)
        {
            RemoveDeviceForm form = new RemoveDeviceForm(parent);
            form.ShowDialog();
        }

        private void showDeviceBtn_Click(object sender, EventArgs e)
        {
            string[] deviceNames = DroneList.GetAllDeviceName(parent);
            if (deviceNames == null)
                return;

            int index = 0;
            foreach (string name in deviceNames)
                parent.UpdateLog("Device" + (index++).ToString() + " Name is " + name + ", AP is " + DroneList.GetDroneInfo(parent, name).GetAPName());
        }
    }
}
