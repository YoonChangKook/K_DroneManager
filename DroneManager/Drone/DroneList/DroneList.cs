using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DroneManager.Drone
{
    public static class DroneList
    {
        private static readonly string DRONE_LIST_NAME = "DroneList.dlist";
        private static readonly object droneListLocker = new object();

        private static Dictionary<string, DroneInfo> GetDroneList(MainForm mainForm)
        {
            BinaryFormatter binFmt = new BinaryFormatter();
            lock (droneListLocker)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(DRONE_LIST_NAME, FileMode.Open);
                }
                catch (FileNotFoundException e)
                {
                    mainForm.ShowMessageBox("Can't find drone list file");
                    return null;
                }
                
                object droneListObj = binFmt.Deserialize(fs);
                try
                {
                    Dictionary<string, DroneInfo> droneList = (Dictionary<string, DroneInfo>)droneListObj;
                    fs.Close();
                    return droneList;
                }
                catch (InvalidCastException e)
                {
                    // When list file is wrong format.
                    mainForm.ShowMessageBox("Drone list file has wrong format.");
                    fs.Close();
                    return null;
                }
            }
        }

        public static bool AddDroneInfo(MainForm mainForm, string id, DroneInfo dInfo)
        {
            BinaryFormatter binFmt = new BinaryFormatter();
            lock (droneListLocker)
            {
                FileStream fs = new FileStream(DRONE_LIST_NAME, FileMode.OpenOrCreate);
                Dictionary<string, DroneInfo> droneList;

                if (fs.Length != 0)
                {
                    object droneListObj = binFmt.Deserialize(fs);
                    try
                    {
                        droneList = (Dictionary<string, DroneInfo>)droneListObj;
                    }
                    catch (InvalidCastException e)
                    {
                        // When list file is wrong format.
                        mainForm.ShowMessageBox("Drone list file has wrong format.");
                        fs.Close();
                        return false;
                    }
                }
                else
                    droneList = new Dictionary<string, DroneInfo>();
                fs.Close();

                if (droneList.ContainsKey(id))
                {
                    mainForm.ShowMessageBox("Device ID is already exist in the table.");
                    fs.Close();
                    return false;
                }

                fs = new FileStream(DRONE_LIST_NAME, FileMode.Create);
                droneList.Add(id, dInfo);
                binFmt.Serialize(fs, droneList);
                fs.Close();
            }

            return true;
        }

        public static bool RemoveDroneInfo(MainForm mainForm, string id)
        {
            BinaryFormatter binFmt = new BinaryFormatter();
            lock (droneListLocker)
            {
                FileStream fs = new FileStream(DRONE_LIST_NAME, FileMode.Open);
                Dictionary<string, DroneInfo> droneList;

                if (fs.Length != 0)
                {
                    object droneListObj = binFmt.Deserialize(fs);
                    try
                    {
                        droneList = (Dictionary<string, DroneInfo>)droneListObj;
                    }
                    catch (InvalidCastException e)
                    {
                        // When list file is wrong format.
                        mainForm.ShowMessageBox("Drone list file has wrong format.");
                        fs.Close();
                        return false;
                    }
                }
                else
                {
                    mainForm.ShowMessageBox("드론 리스트가 존재하지 않습니다.");
                    fs.Close();
                    return false;
                }

                fs.Close();

                if (droneList.ContainsKey(id))
                {
                    droneList.Remove(id);

                    fs = new FileStream(DRONE_LIST_NAME, FileMode.Create);
                    binFmt.Serialize(fs, droneList);
                    fs.Close();

                    return true;
                }
                else
                {
                    mainForm.ShowMessageBox("삭제할 요소가 드론 리스트에 존재하지 않습니다.");
                    return false;
                }
            }
        }

        public static DroneInfo GetDroneInfo(MainForm mainForm, string id)
        {
            Dictionary<string, DroneInfo> droneList = GetDroneList(mainForm);
            if (droneList == null)
                return null;

            if (droneList.ContainsKey(id))
            {
                return droneList[id];
            }
            else
                return null;
        }

        public static string[] GetAllDeviceName(MainForm mainForm)
        {
            Dictionary<string, DroneInfo> droneList = GetDroneList(mainForm);
            if (droneList == null)
                return null;

            string[] deviceNames = new string[droneList.Count];
            droneList.Keys.CopyTo(deviceNames, 0);

            return deviceNames;
        }
    }
}
