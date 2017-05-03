using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.Drone
{
    [Serializable]
    public class DroneInfo
    {
        private string apName;
        private int tagId;

        public DroneInfo(string apName, int tagId)
        {
            this.apName = apName;
            this.tagId = tagId;
        }

        public string GetAPName() { return apName; }
        public int GetTagID() { return tagId; }
    }
}
