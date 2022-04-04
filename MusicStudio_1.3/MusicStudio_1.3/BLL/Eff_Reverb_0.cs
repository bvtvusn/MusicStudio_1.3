using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    public class Eff_Reverb_0 : SoundEffect
    {
        //public override SoundEffect Clone()
        //{
        //    Eff_Reverb_0 other = this.MemberwiseClone() as Eff_Reverb_0;

        //    return other;

            
        //}

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override float StepForward(double pitch, float input, double dt)
        {
            return input;
        }
    }
}
