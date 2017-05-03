using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DroneManager.Drone
{
    // Total 5 byte struct.. (no padding)
    [StructLayout(LayoutKind.Explicit, Pack=1)]
    public struct DroneInfoPacket
    {
        [FieldOffset(0)]
        public byte flyingState;
        [FieldOffset(1)]
        public sbyte battery;
    }

    public static class DroneInfoPacketManager
    {
        public static DroneInfoPacket DroneInfoPack(byte flyingState, sbyte battery)
        {
            DroneInfoPacket packet;
            packet.flyingState = flyingState;
            packet.battery = battery;

            return packet;
        }

        public static byte[] SerializeDroneInfo(DroneInfoPacket packet)
        {
            int rawsize = Marshal.SizeOf(packet);
            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.StructureToPtr(packet, buffer, false);
            byte[] rawdata = new byte[rawsize];
            Marshal.Copy(buffer, rawdata, 0, rawsize);
            Marshal.FreeHGlobal(buffer);
            return rawdata;
        }

        public static DroneInfoPacket? DeserializeDroneInfo(byte[] packetBytes)
        {
            IntPtr buffer = Marshal.AllocHGlobal(packetBytes.Length);
            Marshal.Copy(packetBytes, 0, buffer, packetBytes.Length);
            object obj = Marshal.PtrToStructure(buffer, typeof(DroneInfoPacket));
            Marshal.FreeHGlobal(buffer);
            if (Marshal.SizeOf(obj) != packetBytes.Length)
                return null;
            return (DroneInfoPacket)obj;
        }
    }
}
