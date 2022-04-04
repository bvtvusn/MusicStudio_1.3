using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    public class WaveAdd : SoundEffect
    {
        private double phase;
        private WaveTable _waveTable;

        public WaveTable waveTable { get => _waveTable; set { _waveTable = value; _waveTable.CalcWaveTable(); } }
        //public override SoundEffect Clone()
        //{
        //    WaveAdd other = this.MemberwiseClone() as WaveAdd;
            
        //    return other;
        //}

        

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override float StepForward(double pitch, float input, double dt)
        {

            phase += dt * pitch;
            if (phase >= 1.0) phase -= 1.0;

            float sample = waveTable.GetPoint(phase);
            //float adjustFactor = _adjusterObjects[AdjusterPointer].GetValue();

            float adjFacto2 = RequestAdjuster.Invoke(AdjusterPointer);
            //throw new Exception(); // Adjuster factor returns zero. Probably because it references the template object.
            return (sample + input) * adjFacto2;
            
        }
        
    }
}
