using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DroneManager.Drone;
using CalibrationSpline;

namespace DroneManager.UWB.Calibration
{
    /*
     * 1. Calibration 해주는 모듈
     * 2. Meter, Power로 시간을 반환해주는 모듈
     */
    public abstract class CalibrationManager
    {
        private static readonly object memberLocker = new object();
        private static int calibratedDrone = -1;

        #region CALIBRATION
        public static CalibrationInfo Calibrate(MainForm mainForm, 
            BebopDrone drone, 
            UWBManager uwbManager,
            int tag_id,
            string droneName, 
            int[] powers = null,
            int[] times = null,
            bool overlap = true)
        {
            // Check if drone is already being calibrated.
            lock (memberLocker)
            {
                if (calibratedDrone != -1)
                    return null;
            }

            // Check is there already calibration data, if there is, remove.
            string[] keys = CalibrationList.GetAllCalibratedDroneNames(mainForm);
            CalibrationInfo cInfo;
            if (keys != null)
            {
                if (keys.Contains(droneName))
                {
                    if (!overlap)
                        return null;
                    else
                        cInfo = CalibrationList.GetCalibrationData(mainForm, droneName);
                    //CalibrationList.RemoveCalibrationData(mainForm, droneName);
                }
                else
                    cInfo = new CalibrationInfo();
            }
            else
                cInfo = new CalibrationInfo();

            // x, y, z move calibration
            if (powers == null || powers.Length == 0)
                powers = CalibrationStandard.POWERS;
            foreach(int power in powers)
            {
                mainForm.UpdateCalibrationLog(power.ToString() + " power move calibration");
                //mainForm.UpdateCalibrationLog("Time values: " + CalibrationStandard.TIMES.ToString());
                if (times == null || times.Length == 0)
                    times = CalibrationStandard.TIMES;

                MoveCalibrationInfo mcInfo = cInfo.GetMoveInfo(power);
                MoveCalibration moveCalibration = 
                    new MoveCalibration(mainForm,
                                        power,
                                        times,
                                        drone,
                                        uwbManager,
                                        tag_id);
                List<string[]> csvRows = new List<string[]>();
                moveCalibration.Calibrate(csvRows);
                CSVManager.CSVWrite(power.ToString() + "Log.csv",
                                    new string[] { "Type", "Time", "Meter" },
                                    csvRows);

                if(mcInfo == null)
                    mcInfo = new MoveCalibrationInfo(power,
                                                    moveCalibration.GetTimes(), 
                                                    moveCalibration.GetLeftMeters(), 
                                                    moveCalibration.GetRightMeters(),
                                                    moveCalibration.GetBackMeters(),
                                                    moveCalibration.GetFrontMeters(),
                                                    moveCalibration.GetDownMeters(),
                                                    moveCalibration.GetUpMeters());
                else
                {
                    int[] moveTimes = moveCalibration.GetTimes().ToArray();
                    mcInfo.NullCheck();
                    foreach(int time in moveTimes)
                    {
                        mcInfo.AddLeftMeter(time, moveCalibration.GetLeftMeters()[time]);
                        mcInfo.AddRightMeter(time, moveCalibration.GetRightMeters()[time]);
                        mcInfo.AddBackMeter(time, moveCalibration.GetBackMeters()[time]);
                        mcInfo.AddFrontMeter(time, moveCalibration.GetFrontMeters()[time]);
                        mcInfo.AddDownMeter(time, moveCalibration.GetDownMeters()[time/2]);
                        mcInfo.AddUpMeter(time, moveCalibration.GetUpMeters()[time/2]);
                    }
                }
                cInfo.AddMoveInfo(power, mcInfo);
            }
            // rotation calibration


            mainForm.UpdateCalibrationLog("---Calibration Finish---");

            lock(memberLocker)
                calibratedDrone = -1;

            return cInfo;
        }
        #endregion

        #region GET_DATA
        public static int GetRollTime(MainForm mainForm, 
                                    string droneName,
                                    int power,
                                    double meter)
        {
            CalibrationInfo cInfo = CalibrationList.GetCalibrationData(mainForm, droneName);
            MoveCalibrationInfo mcInfo = cInfo.GetMoveInfo(power);
            if (mcInfo == null)
            {
                mainForm.ShowMessageBox("Power " + power + " data doesn't exist.");
                return -1;
            }

            float[] times = Array.ConvertAll(mcInfo.GetTimes(), x => (float)x); // x
            float[] meters = new float[times.Length];                         // y
            for(int i = 0; i < meters.Length; i++)
                if(power > 0)
                    meters[i] = (float)mcInfo.GetRightMeter((int)times[i]);
                else
                    meters[i] = (float)mcInfo.GetLeftMeter((int)times[i]);

            if(meters.Min() > meter || meters.Max() < meter)
            {
                mainForm.ShowMessageBox("Meter " + meter + " is out of data range.");
                return -1;
            }

            float[] timeResult = CubicSpline.Compute(meters, times, new float[] { (float)meter });
            return (int)timeResult[0];
        }

        public static int GetPitchTime(MainForm mainForm, 
                                    string droneName, 
                                    int power, 
                                    double meter)
        {
            CalibrationInfo cInfo = CalibrationList.GetCalibrationData(mainForm, droneName);
            MoveCalibrationInfo mcInfo = cInfo.GetMoveInfo(power);
            if (mcInfo == null)
            {
                mainForm.ShowMessageBox("Power " + power + " data doesn't exist.");
                return -1;
            }

            float[] times = Array.ConvertAll(mcInfo.GetTimes(), x => (float)x); // x
            float[] meters = new float[times.Length];                         // y
            for (int i = 0; i < meters.Length; i++)
                if (power > 0)
                    meters[i] = (float)mcInfo.GetFrontMeter((int)times[i]);
                else
                    meters[i] = (float)mcInfo.GetBackMeter((int)times[i]);

            if (meters.Min() > meter || meters.Max() < meter)
            {
                mainForm.ShowMessageBox("Meter " + meter + " is out of data range.");
                return -1;
            }

            float[] timeResult = CubicSpline.Compute(meters, times, new float[] { (float)meter });
            return (int)timeResult[0];
        }
        #endregion
    }
}
