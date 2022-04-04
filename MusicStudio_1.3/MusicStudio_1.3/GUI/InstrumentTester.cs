using MusicStudio_1._3.BLL;
using NAudio.Wave;
using System;

namespace MusicStudio_1._3.GUI
{


    class InstrumentTester : ISampleProvider
    {

        public Instrument inst;
        public int sampleRate;
        public WaveFormat WaveFormat { get; private set; }

        private double _Time;
        public event Action EndReachedEvent;
        public double Time
        {
            get { return _Time; }
            set { _Time = value; }
        }
        public double NoteVal
        {
            get
            {
                double tone = Math.Log(inst.Pitch / 440, 2) * 12;
                return tone + 5 * 12;
            }
            set
            {
                inst.Pitch = Math.Pow(2, (value - 5 * 12) / 12) * 440;
            }
        }

        public InstrumentTester(Instrument instrument, double noteVal = 60, int sampleRate = 44100)
        {   this.sampleRate = sampleRate;
            
            inst = instrument;
            NoteVal = noteVal;
            Init();
        }
        
        void Init()
        {
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 1);
        }
        

        public float StepForward()
        {
            double timestep = 1.0 / sampleRate;
            bool gate = (Time < 0.3);
            float sample =  inst.StepForward(timestep, gate);

            Time += timestep;
            return sample;
        }
        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                buffer[i] = StepForward();
                if (Time > 1)
                {
                    EndReachedEvent?.Invoke();
                    return i + 1;
                }
                
            }

            return count;
            
        }
    }
}