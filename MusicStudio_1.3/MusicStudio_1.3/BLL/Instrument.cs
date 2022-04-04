using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MusicStudio_1._3.BLL
{
    public class Instrument
    {
        public List<Adjuster> adjusterObjects;
        public List<SoundEffect> effectObjects;
        private double _pitch;
        private float silencethreshold = 0.001f;
        private double silenceTimer = 0;
        internal bool IsOn { get; set; }
        internal string Name { get; set; }

        public Instrument() { Init(); }

        internal double Pitch {
            get => _pitch;
            set { _pitch = value; UpdatePitch(value); }
        }
        public delegate float GetValDelegate(int index); 
        public float ReturnAdjusterValMethod(int index)
        {
            return adjusterObjects[index].GetValue();
        }
        //public void prepare()
        //{
        //    //GetValDelegate getAdjusterVal = ReturnAdjusterValMethod;
        //    foreach (SoundEffect item in effectObjects)
        //    {
        //        item._adjusterObjects = adjusterObjects;
        //        //item.RequestAdjuster = getAdjusterVal;
        //    }
            
        //}
        private void UpdatePitch(double pitch)
        {
            foreach (var SoundEffect in effectObjects)
            {
                SoundEffect.Pitch = pitch;
            }
        }

        

        //public Instrument(double frequency)
        //{
        //    this.frequency = frequency;
        //}
        void Init()
        {
            // prepare list of objects;
            effectObjects = new List<SoundEffect>();
            adjusterObjects = new List<Adjuster>();
            IsOn = true;
        }


        internal void Dispose()
        {
            
        }


        public float StepForward(double dt, bool gate)
        {
            // go through all the sound generator objects
            float sample = 0;
            for (int i = 0; i < effectObjects.Count; i++)
            {
                sample = effectObjects[i].StepForward(_pitch, sample, dt);
            }

            // Update adjusters
            for (int i = 0; i < adjusterObjects.Count; i++)
            {
                adjusterObjects[i].StepForward(dt,gate);
            }
            if (IsOn) CheckForSilence(sample,dt);

            return sample;
        }

        private void CheckForSilence(float sample, double dt)
        {
            if (sample < silencethreshold)
            {
                silenceTimer += dt;
            }
            else
            {
                silenceTimer = 0;
            }
            if (silenceTimer > 1) // has been silent for one second.
            {
                IsOn = false;
                //MessageBox.Show("testing");
            }
        }

        

        public Instrument GetNewClone()
        {
            Instrument copy = new Instrument();
            //copy.adjusterObjects = new List<Adjuster>();
            //copy.effectObjects = new List<SoundEffect>();

            foreach (Adjuster item in this.adjusterObjects)
            {
                copy.adjusterObjects.Add(item.Clone());
            }
            GetValDelegate getAdjusterVal = copy.ReturnAdjusterValMethod;
            foreach (SoundEffect item in this.effectObjects)
            {
                SoundEffect clonedEffect = item.Clone();
                clonedEffect.RequestAdjuster = getAdjusterVal;
                copy.effectObjects.Add(clonedEffect);
                //copy.effectObjects[.R
            }
            

            return copy;
        }

        public static Instrument CreateSineInstrument()
        {
            Instrument inst = new Instrument();
            inst.Name = "Sine Instrument";
            inst.adjusterObjects.Add(new Envelope(0.01, 0.01, 1, 0.01));

            WaveAdd waveAdd = new WaveAdd();
            waveAdd.waveTable = new WaveTable(WaveTable.MaskType.All, WaveTable.FrequencyDecay.InverseSquare, 0.125, 1);
            waveAdd.waveTable.CalcWaveTable();
            inst.effectObjects.Add(waveAdd);
            inst.effectObjects[0].AdjusterPointer = 0;

            return inst;
        }
    }
}