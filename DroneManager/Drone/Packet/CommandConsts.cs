using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.Drone
{
    public abstract class DroneCommandType
    {
        public readonly static byte DRONE_FLYING = 0;
        public readonly static byte DRONE_PILOTING = 1;
        public readonly static byte ACK = 100;
    }

    public abstract class DroneFlyingMode
    {
        public readonly static byte TAKE_OFF = 0;
        public readonly static byte LAND = 1;        
        public readonly static byte NONE = 100;
    }
}
