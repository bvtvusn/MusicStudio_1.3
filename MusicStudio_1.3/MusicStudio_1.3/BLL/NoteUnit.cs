using System;

namespace MusicStudio_1._3.BLL
{
    public class NoteUnit
    {
        internal bool IsOn { get; set; }

        double duration_;
        double stop_;
        public bool selected = false;
        private Instrument _playInstrument;
        private double _start;

        //public string InstrumentName { get
        //    {
        //        if (_playInstrument == null) return "None";
        //        else return _playInstrument.Name;
        //    } set { } }

        public Instrument PlayInstrument
        {
            get => _playInstrument;
            set
            {
                _playInstrument = value;
                _playInstrument.Pitch = Pitch;
            }
        }
        public NoteUnit(double start, double duration, float volume, double pitch/*, float speed*/)
        {
            Start = start;
            Duration_ = duration;
            Volume = volume;
            Pitch = pitch;
            //Speed = speed;
        }
        public NoteUnit(double start, double noteVal)
        {
            Start = start;
            Duration_ = 0.25;
            Volume = 1;
            NoteVal = noteVal;
            //Speed = speed;
        }
        public NoteUnit() { }

        public double Start { get => _start; set { _start = Math.Max(value,0); } }
        public double Duration_
        {
            get => duration_;
            set
            {
                double newDur = value;
                if (newDur > 0)
                {
                    duration_ = newDur;
                    stop_ = Start + newDur;
                }

            }
        }

        internal void RemovePlayInstrument()
        {
            _playInstrument = null;
        }

        public double Stop_ { get => stop_; }
        public float Volume { get; set; }
        public double Pitch { get; set; }
        public float Speed { get; set; }
        public double NoteVal
        {
            get
            {
                double tone = Math.Log(Pitch / 440, 2) * 12;
                return tone + 5 * 12;
            }
            set
            {
                Pitch = Math.Pow(2, (value - 5 * 12) / 12) * 440;
            }
        }

        internal float StepForward(double songTime, double dt)
        {
            IsOn = PlayInstrument.IsOn;
            if (IsOn == false)
            {
                PlayInstrument.Dispose();
            }

            bool gate = (songTime < stop_);
            return PlayInstrument.StepForward(dt, gate);
            //throw new NotImplementedException(); // Send "Gate" information to Instrument.
        }

        public double GetNoteVal()
        {
            double tone = Math.Log(Pitch / 440, 2) * 12;
            return tone + 5 * 12;
        }

    }
}