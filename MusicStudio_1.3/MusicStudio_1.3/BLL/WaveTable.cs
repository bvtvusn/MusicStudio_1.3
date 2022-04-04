using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    public class WaveTable
    {
        float[] waveform;
        public int samples = 4410;

        //int harmonics;

        //public int Harmonics { get => harmonics; set { harmonics = value; CalcWaveTable(); } }

        MaskType mask;
        FrequencyDecay decayType;
        int cutoff;
        double decayStrength;

        public MaskType MaskUsed { get => mask; set { mask = value; } }
        public FrequencyDecay DecayType { get => decayType; set { decayType = value; } }
        public int Cutoff { get => cutoff; set { cutoff = value; } }
        public double DecayStrength { get => decayStrength; set { decayStrength = value; } }

        public enum MaskType
        {
            All = 1,
            Even = 2,
            Thirds = 3,
            Fourths = 4
        }

        public enum FrequencyDecay
        {
            Linear,
            Reciprocal,
            InverseSquare
        }
        public WaveTable(MaskType mask, FrequencyDecay decayType, double decayStrength, int cutoff)
        {
            waveform = new float[samples];


            this.MaskUsed = mask;
            this.DecayType = decayType;
            this.DecayStrength = decayStrength;
            this.Cutoff = cutoff;

            CalcWaveTable();

            //Testing();
        }
        public WaveTable()
        {
            waveform = new float[samples];
        }

        private void Testing()
        {
            MaskUsed = MaskType.Thirds;
            DecayStrength = 1.0 / 1;
            DecayType = FrequencyDecay.InverseSquare;


            double[] vals = new double[10];
            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = HarmonicDecay(i);
            }
        }

        double MaskState(int harmNum)
        {
            if (harmNum % (int)MaskUsed == 0) return 1.0;
            else return 0.0;
        }

        double HarmonicDecay(double harmNum)
        {
            switch (DecayType)
            {
                case FrequencyDecay.Linear:
                    return Math.Max(0, 1.0 - DecayStrength * harmNum);
                case FrequencyDecay.Reciprocal:
                    return 1.0 / ((harmNum * DecayStrength) + 1);
                case FrequencyDecay.InverseSquare:
                    return 1.0 / Math.Pow((harmNum * DecayStrength) + 1, 2);
            }
            return 0;
            //if (harmNum % (int)mask == 0) return 1;
            //else return 0;
        }

        //float HarmonicDecay(int number)
        //{
        //    return Convert.ToSingle(1.0 / number); ;
        //}

        public void CalcWaveTable()
        {
            for (int i = 0; i < samples; i++)
            {
                for (int j = 1; j <= cutoff; j++)
                {

                    //waveform[i] += (float)HarmonicDecay(j) * Convert.ToSingle(Math.Sin(2.0 * Math.PI * ((1.0 * i * j / samples) % 1.0)));
                    if (i == 300)
                    {

                    }
                    waveform[i] += Convert.ToSingle(MaskState(j - 1) * HarmonicDecay(j - 1) * Math.Sin(2.0 * Math.PI * ((1.0 * i * j / samples) % 1.0)));
                }
            }
        }
        internal float GetPoint(double phase)
        {
            int index = (int)(phase * samples);

            return waveform[index];
        }

        //[OnDeserialized]
        //void OnDeserialized(StreamingContext context)
        //{
        //    CalcWaveTable();
        //}
    }
}
