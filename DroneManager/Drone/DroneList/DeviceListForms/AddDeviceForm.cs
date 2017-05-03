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
    public partial class AddDeviceForm : Form
    {
        private MainForm parent;

        public AddDeviceForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void AddDeviceForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            String deviceName = deviceNameTextBox.Text;
            String apName = apNameTextBox.Text;
            int tagId = -1;
            try
            {
                tagId = int.Parse(tagIdTextBox.Text);
            }
            catch (FormatException ex)
            {
                parent.ShowMessageBox("Please type only number in the tag textbox.");
                this.Close();
            }

            DroneInfo dInfo = new DroneInfo(apName, tagId);
            DroneList.AddDroneInfo(parent, deviceName, dInfo);

            this.Close();
        }
    }
}
