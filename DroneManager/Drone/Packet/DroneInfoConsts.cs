using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.Drone
{
    public abstract class DroneFlyingState
    {
        public readonly static byte LANDED = 0;
        public readonly static byte TAKING_OFF = 1;
        public readonly static byte HOVERING = 2;
        public readonly static byte FLYING = 3;
        public readonly static byte LANDING = 4;
        public readonly static byte EMERGENCY = 5;
        public readonly static byte USER_TAKE_OFF = 6;
        public readonly static byte BREAK = 7;
        public readonly static byte ACK = 100;
        public readonly static byte NONE = 101;
    }
}
