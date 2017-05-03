using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.UWB
{
    public class UWBAnchor
    {
        public int anchorNum;
        public Vector3 anchorPos;

        public UWBAnchor(int anchorNum, double[] anchorPos)
        {
            this.anchorNum = anchorNum;
            this.anchorPos = new Vector3(anchorPos[0], anchorPos[1], anchorPos[2]);
        }
        public UWBAnchor(int anchorNum, double x, double y, double z)
        {
            this.anchorNum = anchorNum;
            this.anchorPos = new Vector3(x, y, z);
        }
        public UWBAnchor(int anchorNum, Vector3 anchorPos)
        {
            this.anchorNum = anchorNum;
            this.anchorPos = anchorPos;
        }
    }
    public class UWBTag
    {
        public int tagNum;
        public Vector3 tagPos;

        public UWBTag(int tagNum, double[] tagPos)
        {
            this.tagNum = tagNum;
            this.tagPos = new Vector3(tagPos[0], tagPos[1], tagPos[2]);
        }
        public UWBTag(int tagNum, double x, double y, double z)
        {
            this.tagNum = tagNum;
            this.tagPos = new Vector3(x, y, z);
        }
        public UWBTag(int tagNum, Vector3 tagPos)
        {
            this.tagNum = tagNum;
            this.tagPos = tagPos;
        }
    }

    public abstract class UWBConsts
    {
        public static readonly int ANCHOR_COUNT = 4;
        public static readonly int[] ANCHOR_TRIANGLE1 = { 0, 1, 2, 3 };
        public static readonly int[] ANCHOR_TRIANGLE2 = { 0, 1, 3, 2 };
    }
}
