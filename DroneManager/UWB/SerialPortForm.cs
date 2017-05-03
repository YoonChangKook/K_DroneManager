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
using DroneManager.UWB;

namespace DroneManager
{
    public partial class SerialPortForm : Form
    {
        private MainForm parent;

        public SerialPortForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            GetSerialPort();
        }

        protected override void WndProc(ref Message m)
        {
            UInt32 WM_DEVICECHANGE = 0x0219;
            UInt32 DBT_DEVTUP_VOLUME = 0x02;
            UInt32 DBT_DEVTUP_PORT = 0x03;
            UInt32 DBT_DEVICEARRIVAL = 0x8000;
            UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL)) //디바이스 연결
            {
                //int m_Count = 0;
                int devType = Marshal.ReadInt32(m.LParam, 4);

                if (devType == DBT_DEVTUP_VOLUME || devType == DBT_DEVTUP_PORT)
                {
                    GetSerialPort();
                }
            }

            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))  //디바이스 연결 해제
            {
                int devType = Marshal.ReadInt32(m.LParam, 4);
                if (devType == DBT_DEVTUP_VOLUME || devType == DBT_DEVTUP_PORT)
                {
                    GetSerialPort();
                }
            }

            base.WndProc(ref m);
        }

        private void GetSerialPort()
        {
            uwbComboBox.Items.Clear();

            try
            {
                foreach (string str in SerialPort.GetPortNames())
                    uwbComboBox.Items.Add(str);
                if (uwbComboBox.Items.Count <= 0)
                    uwbComboBox.Items.Add("연결 장치 없음");
                else
                    uwbComboBox.Items.Add("닫기");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (this.uwbComboBox.SelectedIndex == -1)
            {
                this.parent.ShowMessageBox("시리얼 포트를 선택해주세요.");
                return;
            }

            if (this.uwbComboBox.SelectedIndex == uwbComboBox.Items.Count - 1)
            {
                this.parent.GetUWBManager().SerialPortClose();
            }
            else
            {
                string portName = this.uwbComboBox.SelectedItem.ToString();
                this.parent.GetUWBManager().SerialPortOpen(portName);
            }

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
