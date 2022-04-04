using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    public class Envelope : Adjuster
    {
        double stateTime = 0;
        private double release;
        private float sustain;
        private State _state1 = State.Attack;
        private double attack;
        private double decay;

        internal State EnvelopeState { get => _state1; set => _state1 = value; }
        public double Attack { get => attack; set => attack = value; }
        public double Decay { get => decay; set => decay = value; }
        public double Release { get => release; set => release = value; }
        public float Sustain { get => sustain; set => sustain = value; }

        //internal bool IsOn { get => (_state1 != State.Off); }

        internal enum State
        {
            Attack,
            Decay,
            Sustain,
            Release,
            Off
        }

        public Envelope(double attack, double decay, float sustain, double release)
        {
            this.Attack = attack;
            this.Decay = decay;
            this.Sustain = sustain;
            this.Release = release;
        }
        public Envelope() { }
        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        
        public override void StepForward(double dt, bool gate)
        {
            _returnVal = EnvelopeLogic(dt, gate);
        }


        public float EnvelopeLogic(double dt, bool pressed)
        {
            float val = 0;
            stateTime += dt;
            switch (EnvelopeState)
            {
                case State.Attack:

                    val = Convert.ToSingle(stateTime / Attack);
                    if (stateTime >= Attack) NextState();
                    return val;
                case State.Decay:
                    val = Convert.ToSingle(1 - (1 - Sustain) * (stateTime / Decay));
                    if (stateTime >= Decay) NextState();
                    return val;
                case State.Sustain:
                    if (!pressed) NextState();
                    return Sustain;
                case State.Release:
                    val = Convert.ToSingle(Sustain - (Sustain) * (stateTime / Release));
                    if (pressed) { EnvelopeState = State.Attack; stateTime = 0; }
                    if (val < 0.0001) { EnvelopeState = State.Off; stateTime = 0; }
                    return val;
                case State.Off:
                    if (pressed) EnvelopeState = State.Attack; stateTime = 0;
                    return 0f;
                default:
                    return 0f;
            }
        }

        void NextState()
        {
            EnvelopeState++;
            stateTime = 0;
        }
    }
}
