using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DroneManager.UWB.Calibration
{
    public static class CalibrationList
    {
        private static readonly string CALIBRATION_LIST_NAME = "CalibrationList.clist";
        private static readonly object calibrationListLocker = new object();

        private static Dictionary<string, CalibrationInfo> GetCalibrationList(MainForm mainForm)
        {
            BinaryFormatter binFmt = new BinaryFormatter();
            lock (calibrationListLocker)
            {
                FileStream fs;
                try
                {
                    fs = new FileStream(CALIBRATION_LIST_NAME, FileMode.Open);
                }
                catch (FileNotFoundException e)
                {
                    mainForm.ShowMessageBox("Can't find calibration list file");
                    return null;
                }

                object calibrationListObj = binFmt.Deserialize(fs);
                try
                {
                    Dictionary<string, CalibrationInfo> calibrationList = 
                        (Dictionary<string, CalibrationInfo>)calibrationListObj;
                    fs.Close();
                    return calibrationList;
                }
                catch (InvalidCastException e)
                {
                    // When list file is wrong format.
                    mainForm.ShowMessageBox("Calibration list file has wrong format.");
                    fs.Close();
                    return null;
                }
            }
        }

        public static bool AddCalibrationData(MainForm mainForm, string droneName, CalibrationInfo cInfo)
        {
            BinaryFormatter binFmt = new BinaryFormatter();
            lock (calibrationListLocker)
            {
                FileStream fs = new FileStream(CALIBRATION_LIST_NAME, FileMode.OpenOrCreate);
                Dictionary<string, CalibrationInfo> calibrationList;

                if (fs.Length != 0)
                {
                    object calibrationListObj = binFmt.Deserialize(fs);
                    try
                    {
                        calibrationList = (Dictionary<string, CalibrationInfo>)calibrationListObj;
                    }
                    catch (InvalidCastException e)
                    {
                        // When list file is wrong format.
                        mainForm.ShowMessageBox("Calibration list file has wrong format.");
                        fs.Close();
                        return false;
                    }
                }
                else
                    calibrationList = new Dictionary<string, CalibrationInfo>();
                fs.Close();

                if (calibrationList.ContainsKey(droneName))
                {
                    calibrationList.Remove(droneName);
                    //mainForm.ShowMessageBox("The drone's calibration data is already exist in the table.");
                    //fs.Close();
                    //return false;
                }

                fs = new FileStream(CALIBRATION_LIST_NAME, FileMode.Create);
                calibrationList.Add(droneName, cInfo);
                binFmt.Serialize(fs, calibrationList);
                fs.Close();
            }

            return true;
        }

        public static void RemoveCalibrationData(MainForm mainForm, string droneName)
        {
            BinaryFormatter binFmt = new BinaryFormatter();
            lock (calibrationListLocker)
            {
                FileStream fs = new FileStream(CALIBRATION_LIST_NAME, FileMode.OpenOrCreate);
                Dictionary<string, CalibrationInfo> calibrationList;

                if (fs.Length != 0)
                {
                    object calibrationListObj = binFmt.Deserialize(fs);
                    try
                    {
                        calibrationList = (Dictionary<string, CalibrationInfo>)calibrationListObj;
                    }
                    catch (InvalidCastException e)
                    {
                        // When list file is wrong format.
                        mainForm.ShowMessageBox("Calibration list file has wrong format.");
                        fs.Close();
                        return;
                    }
                }
                else
                {
                    mainForm.ShowMessageBox("There's no calibration data.");
                    fs.Close();
                    return;
                }
                fs.Close();

                if (!calibrationList.ContainsKey(droneName))
                {
                    mainForm.ShowMessageBox("The drone's calibration data isn't exist in the table.");
                    fs.Close();
                    return;
                }

                fs = new FileStream(CALIBRATION_LIST_NAME, FileMode.Create);
                calibrationList.Remove(droneName);
                binFmt.Serialize(fs, calibrationList);
                fs.Close();
            }
        }

        public static CalibrationInfo GetCalibrationData(MainForm mainForm, string droneName)
        {
            Dictionary<string, CalibrationInfo> calibrationList = GetCalibrationList(mainForm);
            if (calibrationList == null)
                return null;

            if (calibrationList.ContainsKey(droneName))
            {
                return calibrationList[droneName];
            }
            else
                return null;
        }

        public static string[] GetAllCalibratedDroneNames(MainForm mainForm)
        {
            Dictionary<string, CalibrationInfo> droneList = GetCalibrationList(mainForm);
            if (droneList == null)
                return null;

            string[] deviceNames = new string[droneList.Count];
            droneList.Keys.CopyTo(deviceNames, 0);

            return deviceNames;
        }
    }
}
