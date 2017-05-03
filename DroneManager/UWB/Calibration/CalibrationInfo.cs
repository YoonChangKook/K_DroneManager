using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneManager.UWB.Calibration
{
    /*
     * UWB를 이용해
     * power: 30, 60, 90
     * roll, pitch, yaw에 대한 값으로
     * time: 500, 1000, 1500
     * 에 대한 이동 값을 획득
     * 회전은 90도, 180도 수동으로 획득
     */
    public abstract class CalibrationGoal
    {
        public static readonly double[] METERS = { 1.0, 1.5, 2.0 };
        public static readonly double[] DEGREES = { 90.0, 180.0 };
    }
    public abstract class CalibrationStandard
    {
        public static readonly int[] POWERS = { 50 };
        public static readonly int[] TIMES = { 1000 };
    }
    public abstract class CalibrationCollect
    {
        public static readonly int POS_COLLECT_COUNT = 10;
    }

    #region CalibrationData
    [Serializable]
    public class MoveCalibrationInfo
    {
        // power
        private int power;
        // powers
        private List<int> times;
        // meter per power * time
        private Dictionary<int, double> leftMeter;
        private Dictionary<int, double> rightMeter;
        private Dictionary<int, double> frontMeter;
        private Dictionary<int, double> backMeter;
        private Dictionary<int, double> downMeter;
        private Dictionary<int, double> upMeter;

        public MoveCalibrationInfo(int power, List<int> times)
        {
            this.power = power;
            this.times = times;
            this.leftMeter = new Dictionary<int, double>();
            this.rightMeter = new Dictionary<int, double>();
            this.frontMeter = new Dictionary<int, double>();
            this.backMeter = new Dictionary<int, double>();
            this.downMeter = new Dictionary<int, double>();
            this.upMeter = new Dictionary<int, double>();
        }
        public MoveCalibrationInfo(int power,
                            List<int> times,
                            Dictionary<int, double> leftMeter,
                            Dictionary<int, double> rightMeter,
                            Dictionary<int, double> backMeter,
                            Dictionary<int, double> frontMeter,
                            Dictionary<int, double> downMeter,
                            Dictionary<int, double> upMeter)
        {
            this.power = power;
            this.times = times;
            this.leftMeter = leftMeter;
            this.rightMeter = rightMeter;
            this.backMeter = backMeter;
            this.frontMeter = frontMeter;
            this.downMeter = downMeter;
            this.upMeter = upMeter;
        }

        public void NullCheck()
        {
            if (this.times == null) this.times = new List<int>();
            if (this.leftMeter == null) this.leftMeter = new Dictionary<int, double>();
            if (this.rightMeter == null) this.rightMeter = new Dictionary<int, double>();
            if (this.backMeter == null) this.backMeter = new Dictionary<int, double>();
            if (this.frontMeter == null) this.frontMeter = new Dictionary<int, double>();
            if (this.downMeter == null) this.downMeter = new Dictionary<int, double>();
            if (this.upMeter == null) this.upMeter = new Dictionary<int, double>();
        }

        public void AddTime(int time) { this.times.Add(time); }
        public void AddLeftMeter(int time, double meter)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else 
            {
                if(this.leftMeter.ContainsKey(time))
                    this.leftMeter.Remove(time);
                this.leftMeter.Add(time, meter);
            }
        }
        public void AddRightMeter(int time, double meter)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                if(this.rightMeter.ContainsKey(time))
                    this.rightMeter.Remove(time);
                this.rightMeter.Add(time, meter);
            }
        }
        public void AddBackMeter(int time, double meter)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                if(this.backMeter.ContainsKey(time))
                    this.backMeter.Remove(time);
                this.backMeter.Add(time, meter);
            }
        }
        public void AddFrontMeter(int time, double meter)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                if(this.frontMeter.ContainsKey(time))
                    this.frontMeter.Remove(time);
                this.frontMeter.Add(time, meter);
            }
        }
        public void AddDownMeter(int time, double meter)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                if(this.downMeter.ContainsKey(time))
                    this.downMeter.Remove(time);
                this.downMeter.Add(time, meter);
            }
        }
        public void AddUpMeter(int time, double meter)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                if(this.upMeter.ContainsKey(time))
                    this.upMeter.Remove(time);
                this.upMeter.Add(time, meter);
            }
        }
        
        public double GetPower() { return this.power; }
        public int[] GetTimes() { return this.times.ToArray(); }
        public double GetLeftMeter(int time)
        {
            if(!this.times.Contains(time) ||
                this.leftMeter.ContainsKey(time))
                return -1;
            else
                return this.leftMeter[time];
        }
        public double GetRightMeter(int time)
        {
            if (!this.times.Contains(time) ||
                this.rightMeter.ContainsKey(time))
                return -1;
            else
                return this.rightMeter[time];
        }
        public double GetBackMeter(int time)
        {
            if (!this.times.Contains(time) ||
                this.backMeter.ContainsKey(time))
                return -1;
            else
                return this.backMeter[time];
        }
        public double GetFrontMeter(int time)
        {
            if (!this.times.Contains(time) ||
                this.frontMeter.ContainsKey(time))
                return -1;
            else
                return this.frontMeter[time];
        }
        public double GetDownMeter(int time)
        {
            if (!this.times.Contains(time) ||
                this.downMeter.ContainsKey(time))
                return -1;
            else
                return this.backMeter[time];
        }
        public double GetUpMeter(int time)
        {
            if (!this.times.Contains(time) ||
                this.upMeter.ContainsKey(time))
                return -1;
            else
                return this.upMeter[time];
        }
    }

    [Serializable]
    public class RotateCalibrationInfo
    {
        // power
        private int power;
        // times
        private List<int> times;
        // time to goal per power
        private Dictionary<int, double> leftAngle;
        private Dictionary<int, double> rightAngle;

        public RotateCalibrationInfo(int power, List<int> times)
        {
            this.power = power;
            this.times = times;
            this.leftAngle = new Dictionary<int, double>();
            this.rightAngle = new Dictionary<int, double>();
        }

        public void AddTime(int time) { this.times.Add(time); }
        public void AddLeftAngle(int time, double angle)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                this.leftAngle.Remove(time);
                this.leftAngle.Add(time, angle);
            }
        }
        public void AddRightAngle(int time, double angle)
        {
            if (!this.times.Contains(time))
                AddTime(time);
            else
            {
                this.rightAngle.Remove(time);
                this.rightAngle.Add(time, angle);
            }
        }

        public double GetPower() { return this.power; }
        public int[] GetTimes() { return this.times.ToArray(); }
        public double GetLeftAngle(int time)
        {
            if (!this.times.Contains(time) ||
                this.leftAngle.ContainsKey(time))
                return -1;
            else
                return this.leftAngle[time];
        }
        public double GetRightAngle(int time)
        {
            if (!this.times.Contains(time) ||
                this.rightAngle.ContainsKey(time))
                return -1;
            else
                return this.rightAngle[power];
        }
    }

    [Serializable]
    public class CalibrationInfo
    {
        // Calibration infos per power
        private Dictionary<int, MoveCalibrationInfo> moveInfos;
        private Dictionary<int, RotateCalibrationInfo> rotateInfos;

        public CalibrationInfo()
        {
            this.moveInfos = new Dictionary<int, MoveCalibrationInfo>();
            this.rotateInfos = new Dictionary<int, RotateCalibrationInfo>();
        }

        public void AddMoveInfo(int power, MoveCalibrationInfo info)
        {
            RemoveMoveInfo(power);
            moveInfos.Add(power, info);
        }
        public void AddRotateInfo(int power, RotateCalibrationInfo info)
        {
            RemoveRotateInfo(power);
            rotateInfos.Add(power, info);
        }
        public void RemoveMoveInfo(int power)
        {
            if (moveInfos.ContainsKey(power))
                moveInfos.Remove(power);
        }
        public void RemoveRotateInfo(int power)
        {
            if (rotateInfos.ContainsKey(power))
                rotateInfos.Remove(power);
        }

        public int[] GetMovePowers() { return moveInfos.Keys.ToArray(); }
        public int[] GetRotatePowers() { return rotateInfos.Keys.ToArray(); }
        public MoveCalibrationInfo GetMoveInfo(int power)
        {
            if (moveInfos.ContainsKey(power))
                return moveInfos[power];
            else
                return null;
        }
        public RotateCalibrationInfo GetRotationInfo(int power)
        {
            if (rotateInfos.ContainsKey(power))
                return rotateInfos[power];
            else
                return null;
        }
    }
    #endregion
}
