using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace DroneManager.UWB
{
    public class UWBManager
    {
        private MainForm mainForm;

        private Dictionary<int, UWBAnchor> anchors;
        private Dictionary<int, UWBTag> tags;
        public delegate void UpdateTagDelegate(Vector3 pos);
        private Dictionary<int, UpdateTagDelegate> tagUpdateDelegates;
        private SerialPort sp;
        private List<string> packetStrs;
        private string bufferStr;

        public UWBManager(MainForm mainForm)
        {
            this.mainForm = mainForm;

            anchors = new Dictionary<int, UWBAnchor>();
            anchors.Add(0, new UWBAnchor(0, 0, 1.81, 0));
            anchors.Add(1, new UWBAnchor(1, 3.6, 1.81, 0));
            anchors.Add(2, new UWBAnchor(2, 0, 1.81, 3.6));
            anchors.Add(3, new UWBAnchor(3, 0, 0.11, 0));

            tags = new Dictionary<int, UWBTag>();
            tagUpdateDelegates = new Dictionary<int, UpdateTagDelegate>();
            //tags.Add(0, new UWBTag(0, 0, 0, 0));

            sp = new SerialPort();
            packetStrs = new List<string>();
            bufferStr = "";
            sp.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
        }

        public void SerialPortOpen(string portName)
        {
            SerialPortClose();

            sp.PortName = portName;
            sp.Open();
        }
        public void SerialPortClose()
        {
            if (sp.IsOpen == true)
                sp.Close();
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bufferStr += sp.ReadExisting();
            packetStrs.Clear();

            if (bufferStr.Length >= TREK_Manager.PACKET_SIZE)
            {
                packetStrs.AddRange(Split(bufferStr, TREK_Manager.PACKET_SIZE));
                bufferStr = "";
                foreach (string packetStr in packetStrs)
                {
                    if (packetStr.Length != TREK_Manager.PACKET_SIZE)
                        bufferStr += packetStr;
                    else
                    {
                        TREK_Packet? packet = TREK_Manager.Deserialize(packetStr);
                        if (packet == null)
                            //mainForm.UpdateUWB(null, -1);
                            mainForm.UpdateUWBLog("ERROR");
                            //continue;
                        else
                        {
                            if (packet.Value.type == 'c')
                            {
                                Vector3 o1 = Vector3.zero;
                                bool result = Trilateration.GetLocation(ref o1,
                                    anchors,
                                    UWBConsts.ANCHOR_TRIANGLE1,
                                    UWBConsts.ANCHOR_TRIANGLE2,
                                    packet.Value.range);

                                //mainForm.UpdateUWB(o1, packet.Value.tag_id);
                                mainForm.UpdateUWBLog(
                                    String.Format(packet.Value.tag_id + 
                                                " x: {0:00.00}m, y: {1:00.00}m, z: {2:00.00}m\n",
                                                o1.x, o1.y, o1.z));
                                mainForm.UpdateUWBGL();
                                UpdateTag(o1, packet.Value.tag_id);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateTag(Vector3 pos, int tag_id)
        {
            if (tags.ContainsKey(tag_id))
                tags[tag_id].tagPos = pos;
            else
                AddTag(tag_id, pos);

            // Occur Tag Update Event
            if (tagUpdateDelegates.ContainsKey(tag_id))
                tagUpdateDelegates[tag_id].Invoke(pos);
        }

        private static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

        public void AddTag(int tag_id, Vector3 pos) {
            if (tags.ContainsKey(tag_id))
                tags[tag_id] = new UWBTag(tag_id, pos);
            else
                tags.Add(tag_id, new UWBTag(tag_id, pos));
        }
        public void RemoveTag(int tag_id) {
            if(tags.ContainsKey(tag_id))
                tags.Remove(tag_id);
        }

        public void AddTagEvent(int tag_id, UpdateTagDelegate tag_delegate)
        {
            if (tagUpdateDelegates.ContainsKey(tag_id))
                tagUpdateDelegates[tag_id] += tag_delegate;
            else
                tagUpdateDelegates.Add(tag_id, tag_delegate);
        }
        public void RemoveTagEvent(int tag_id)
        {
            if (tagUpdateDelegates.ContainsKey(tag_id))
                tagUpdateDelegates.Remove(tag_id);
        }

        public int[] GetTagKeys() { return tags.Keys.ToArray(); }
        public Vector3 GetTagPos(int key) { return tags[key].tagPos; }
        public int[] GetAnchorKeys() { return anchors.Keys.ToArray(); }
        public Vector3 GetAnchorPos(int key) { return anchors[key].anchorPos; }
    }
}
