using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.UWB
{
    public struct TREK_Packet
    {
        public char type;              // anchor's signal('a') or tag's signal('c')
        public int mask;               // what anchor is exist
        public int[] range;            // distance from the anchors (mm)
        public int lnum;
        public int seq;
        public int rangeTime;
        public char connectedType;      // anchor or tag
        public int tag_id;             // what tag's signal
        public int anchor_id;          // connected anchor index
    }

    public abstract class TREK_Manager
    {
        public static readonly int PACKET_SIZE = 65;

        public static TREK_Packet? Deserialize(string data)
        {
            TREK_Packet result = new TREK_Packet();
            string[] splitDatas = data.Split(' ');
            int dataIndex = 0;

            if (splitDatas[dataIndex].Length != 2)
                return null;
            else
                result.type = splitDatas[dataIndex++][1];

            result.mask = Convert.ToInt32(splitDatas[dataIndex++], 16);
            result.range = new int[4];
            for (int i = 0; i < 4; i++)
                result.range[i] = Convert.ToInt32(splitDatas[dataIndex++], 16);
            result.lnum = Convert.ToInt32(splitDatas[dataIndex++], 16);
            result.seq = Convert.ToInt32(splitDatas[dataIndex++], 16);
            result.rangeTime = Convert.ToInt32(splitDatas[dataIndex++], 16);
            if (splitDatas[dataIndex].Length != 6)
                return null;
            else
            {
                result.connectedType = splitDatas[dataIndex][0];
                result.tag_id = int.Parse(splitDatas[dataIndex][1].ToString());
                result.anchor_id = int.Parse(splitDatas[dataIndex][3].ToString());
            }

            return result;
        }
    }
}
