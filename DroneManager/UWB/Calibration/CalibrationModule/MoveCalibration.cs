using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DroneManager.Drone;

namespace DroneManager.UWB.Calibration
{
    class MoveCalibration
    {
        public static readonly int METER_COLLECT_COUNT = 3;
        public static readonly int POS_COLLECT_COUNT = 10;

        private MainForm mainForm;
        // Standards
        private int power;
        private List<int> times;
        // Datas
        private Dictionary<int, double> leftMeter;
        private Dictionary<int, double> rightMeter;
        private Dictionary<int, double> frontMeter;
        private Dictionary<int, double> backMeter;
        private Dictionary<int, double> downMeter;
        private Dictionary<int, double> upMeter;

        private BebopDrone drone;
        private UWBManager uwbManager;
        private int tag_id;

        public MoveCalibration(MainForm mainForm,
                                int power,
                                int[] times,
                                BebopDrone drone,
                                UWBManager uwbManager, 
                                int tag_id)
        {
            this.mainForm = mainForm;
            this.power = power;
            this.times = new List<int>(times);
            this.drone = drone;
            this.uwbManager = uwbManager;
            this.tag_id = tag_id;
            this.leftMeter = null;
            this.rightMeter = null;
            this.backMeter = null;
            this.frontMeter = null;
            this.downMeter = null;
            this.upMeter = null;
        }

        public void Initialize()
        {
            leftMeter = new Dictionary<int, double>();
            rightMeter = new Dictionary<int, double>();
            frontMeter = new Dictionary<int, double>();
            backMeter = new Dictionary<int, double>();
            downMeter = new Dictionary<int, double>();
            upMeter = new Dictionary<int, double>();
        }

        public void Calibrate(List<string[]> csvRows)
        {
            Initialize();

            foreach (int time in this.times)
            {
                List<double> collectMeters1 = new List<double>();
                List<double> collectMeters2 = new List<double>();
                int pDirection = this.power;

                if (drone.GetFlyingState() == DroneFlyingState.LANDED ||
                    drone.GetFlyingState() == DroneFlyingState.LANDING)
                    drone.TakeOff();

                while (drone.GetFlyingState() == DroneFlyingState.LANDED ||
                    drone.GetFlyingState() == DroneFlyingState.LANDING || 
                    drone.GetFlyingState() == DroneFlyingState.TAKING_OFF) { }

                mainForm.UpdateCalibrationLog("Roll Calibration Start");

                // roll calibration
                while (collectMeters1.Count < METER_COLLECT_COUNT || 
                        collectMeters2.Count < METER_COLLECT_COUNT)
                {
                    pDirection = -pDirection;
                    double moveLength = GetMoveLength(pDirection, 0, 0, (short)time);
                    if (moveLength == -1.0)
                    {
                        mainForm.ShowMessageBox("Calibration Fail (Time out)");
                        return;
                    }
                    mainForm.UpdateCalibrationLog(String.Format("MoveLength: {0:00.00}", moveLength));
                    if (pDirection < 0)
                        collectMeters1.Add(moveLength); // left
                    else
                        collectMeters2.Add(moveLength); // right
                }

                leftMeter.Add(time, collectMeters1.Average(item => item));
                rightMeter.Add(time, collectMeters2.Average(item => item));

                for (int i = 0; i < METER_COLLECT_COUNT; i++)
                    csvRows.Add(new string[] { "Left Try", time.ToString(), collectMeters1[i].ToString() });
                csvRows.Add(new string[] { "Left Result", time.ToString(), leftMeter[time].ToString() });

                for (int i = 0; i < METER_COLLECT_COUNT; i++)
                    csvRows.Add(new string[] { "Right Try", time.ToString(), collectMeters2[i].ToString() });
                csvRows.Add(new string[] { "Right Result", time.ToString(), rightMeter[time].ToString() });

                collectMeters1.Clear();
                collectMeters2.Clear();
                
                // pitch calibration
                while (collectMeters1.Count < METER_COLLECT_COUNT ||
                        collectMeters2.Count < METER_COLLECT_COUNT)
                {
                    pDirection = -pDirection;
                    double moveLength = GetMoveLength(0, pDirection, 0, (short)time);
                    if (moveLength == -1.0)
                    {
                        mainForm.ShowMessageBox("Calibration Fail (Time out)");
                        return;
                    }
                    mainForm.UpdateCalibrationLog(String.Format("MoveLength: {0:00.00}", moveLength));
                    if (pDirection < 0)
                        collectMeters1.Add(moveLength); // back
                    else
                        collectMeters2.Add(moveLength); // front
                }

                backMeter.Add(time, collectMeters1.Average(item => item));
                frontMeter.Add(time, collectMeters2.Average(item => item));

                for (int i = 0; i < METER_COLLECT_COUNT; i++)
                    csvRows.Add(new string[] { "Back Try", time.ToString(), collectMeters1[i].ToString() });
                csvRows.Add(new string[] { "Back Result", time.ToString(), backMeter[time].ToString() });

                for (int i = 0; i < METER_COLLECT_COUNT; i++)
                    csvRows.Add(new string[] { "Front Try", time.ToString(), collectMeters2[i].ToString() });
                csvRows.Add(new string[] { "Front Result", time.ToString(), frontMeter[time].ToString() });

                collectMeters1.Clear();
                collectMeters2.Clear();

                // gaz calibration
                //logLines.Add("TIME: " + time / 2);
                while (collectMeters1.Count < METER_COLLECT_COUNT ||
                        collectMeters2.Count < METER_COLLECT_COUNT)
                {
                    pDirection = -pDirection;
                    double moveLength = GetMoveLength(0, 0, pDirection, (short)(time/2));
                    if (moveLength == -1.0)
                    {
                        mainForm.ShowMessageBox("Calibration Fail (Time out)");
                        return;
                    }
                    mainForm.UpdateCalibrationLog(String.Format("MoveLength: {0:00.00}", moveLength));
                    if (pDirection < 0)
                        collectMeters1.Add(moveLength); // down
                    else
                        collectMeters2.Add(moveLength); // up
                }

                downMeter.Add(time/2, collectMeters1.Average(item => item));
                upMeter.Add(time/2, collectMeters2.Average(item => item));

                for (int i = 0; i < METER_COLLECT_COUNT; i++)
                    csvRows.Add(new string[] { "Down Try", (time / 2).ToString(), collectMeters1[i].ToString() });
                csvRows.Add(new string[] { "Down Result", (time / 2).ToString(), downMeter[time / 2].ToString() });

                for (int i = 0; i < METER_COLLECT_COUNT; i++)
                    csvRows.Add(new string[] { "Up Try", (time / 2).ToString(), collectMeters2[i].ToString() });
                csvRows.Add(new string[] { "Up Result", (time / 2).ToString(), upMeter[time / 2].ToString() });
            }

            drone.Land();

            mainForm.UpdateCalibrationLog(String.Format("Power {0} calibration finish", this.power));
            //File.WriteAllLines(String.Format("{0}LOG.txt", this.power), logLines.ToArray());
        }

        private double GetMoveLength(int rp, int pp, int gp, short time)
        {
            List<Vector3> posStack = new List<Vector3>();
            Vector3 startPos = Vector3.zero;
            Vector3 endPos = Vector3.zero;
            bool ackFail = false;

            // Start Pos
            uwbManager.AddTagEvent(this.tag_id, delegate(Vector3 pos)
            {
                if (gp == 0)
                    posStack.Add(new Vector3(pos.x, 0.0, pos.z));
                else
                    posStack.Add(new Vector3(0.0, pos.y, 0.0));
            });
            while (posStack.Count < POS_COLLECT_COUNT) { Thread.Sleep(200); }
            uwbManager.RemoveTagEvent(this.tag_id);
            startPos = new Vector3(posStack.Average(item => item.x),
                                    posStack.Average(item => item.y),
                                    posStack.Average(item => item.z));
            posStack.Clear();
            mainForm.UpdateCalibrationLog(String.Format("Start Pos: {0:00.00}, {1:00.00}, {2:00.00}",
                                                        startPos.x, startPos.y, startPos.z));

            // Move
            drone.PCMD_Move((sbyte)rp, (sbyte)pp, 0, (sbyte)gp, time);

            // End Pos
            drone.AddACKCheckEvent(delegate()
            {
                Timer timer = new Timer(delegate(object state)
                {
                    uwbManager.AddTagEvent(this.tag_id, delegate(Vector3 pos)
                    {
                        if (gp == 0)
                            posStack.Add(new Vector3(pos.x, 0.0, pos.z));
                        else
                            posStack.Add(new Vector3(0.0, pos.y, 0.0));
                    });
                }, null, time, Timeout.Infinite);
            }, 2000, "Calibration time out.",
            delegate()
            {
                uwbManager.RemoveTagEvent(this.tag_id);
                ackFail = true;
            });

            while (posStack.Count < POS_COLLECT_COUNT) {
                Thread.Sleep(200);
                if (ackFail) return -1.0; }
            uwbManager.RemoveTagEvent(this.tag_id);
            endPos = new Vector3(posStack.Average(item => item.x),
                                    posStack.Average(item => item.y),
                                    posStack.Average(item => item.z));
            posStack.Clear();
            mainForm.UpdateCalibrationLog(String.Format("End Pos: {0:00.00}, {1:00.00}, {2:00.00}",
                                                        endPos.x, endPos.y, endPos.z));

            return Trilateration.vdist(startPos, endPos);
        }

        public int GetPower() { return this.power; }
        public List<int> GetTimes() { return this.times; }
        public Dictionary<int, double> GetLeftMeters() { return this.leftMeter; }
        public Dictionary<int, double> GetRightMeters() { return this.rightMeter; }
        public Dictionary<int, double> GetBackMeters() { return this.backMeter; }
        public Dictionary<int, double> GetFrontMeters() { return this.frontMeter; }
        public Dictionary<int, double> GetDownMeters() { return this.downMeter; }
        public Dictionary<int, double> GetUpMeters() { return this.upMeter; }
    }
}
