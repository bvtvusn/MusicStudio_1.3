using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
   public class Snap
    {
        public bool EnableWholeNote { get => _enableWholeNote; set { _enableWholeNote = value; } }
        public bool EnableWhole { get => _enableWhole; set { _enableWhole = value; Generate(); } }
        public bool Enable1_2 { get => _enable1_2; set { _enable1_2 = value; Generate(); } }
        public bool Enable1_4 { get => _enable1_4; set { _enable1_4 = value; Generate(); } }
        public bool Enable1_8 { get => _enable1_8; set { _enable1_8 = value; Generate(); } }
        public bool Enable1_3 { get => _enable1_3; set { _enable1_3 = value; Generate(); } }

        List<double> snappedValues;
        private bool _enableWholeNote;
        private bool _enableWhole;
        private bool _enable1_2;
        private bool _enable1_4;
        private bool _enable1_8;
        private bool _enable1_3;

        public Snap()
        {
            //snappedValues = new List<double>();
        }

        void Generate()
        {
            snappedValues = new List<double>();
            if (EnableWhole) AddSnapStop(1);
            if (Enable1_2) AddSnapStop(2);
            if (Enable1_4) AddSnapStop(4);
            if (Enable1_8) AddSnapStop(8);
            if (Enable1_3) AddSnapStop(3);

            PrepareSnapList();

        }

        private void PrepareSnapList()
        {
            snappedValues.Sort();
            double prev = 99;
            for (int i = snappedValues.Count - 1; i >= 0; i--)
            {
                if (Math.Abs(prev - snappedValues[i]) < 0.0001)
                {
                    snappedValues.RemoveAt(i);
                }
                else
                {
                    prev = snappedValues[i];
                }
            }
            if (snappedValues.Count > 0) snappedValues.Add(1);
        }

        void AddSnapStop(double snapDivisor)
        {
            for (int i = 0; i < snapDivisor; i++)
            {
                snappedValues.Add(1.0 / snapDivisor * i);
            }
        }
        public void SnapToGrid(ref double time, ref double tone)
        {
            double floor = Math.Floor(time);
            time = time % 1;
            
            

            if (EnableWholeNote)
            {
                tone = Math.Round(tone);
            }

            if (snappedValues == null) { time = time + floor; return; }
            else if (snappedValues.Count == 0) { time = time + floor; return; }

            double minDist = 1;
            double result = 0;
            for (int i = 0; i < snappedValues.Count; i++)
            {
                double dist = Math.Abs(snappedValues[i] - time % 1);
                if (dist < minDist)
                {
                    minDist = dist;
                    result = snappedValues[i];
                }
            }
            time = result + floor;
        }

        double SnapHelper(double value, double snapDivisor)
        {
            return Math.Round(value * snapDivisor) / snapDivisor;
        }
    }
}
