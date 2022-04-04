using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    public class Adj_LFO : Adjuster
    {
        //public override Adjuster Clone()
        //{
        //    Adj_LFO other = this.MemberwiseClone() as Adj_LFO;
        //    return other;
        //}

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        

        //public override void StepForward(double dt)
        //{
            
        //}

        public override void StepForward(double dt, bool gate)
        {
            this._returnVal = 0;
        }
    }
}
