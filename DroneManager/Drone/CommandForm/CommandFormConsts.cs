using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneManager.Drone
{
    public partial class CommandModifyForm : Form
    {
        public abstract class CommandComboBoxConsts
        {
            public static readonly string TAKE_OFF = "TAKE_OFF";
            public static readonly string LAND = "LAND";
            public static readonly string PILOTING = "PILOTING";
        }
    }
}
