using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicStudio_1._3.BLL
{
    [XmlInclude(typeof(Adj_LFO))]

    [XmlInclude(typeof(Envelope))]
    public abstract class Adjuster:IDisposable
    {
        public abstract void StepForward(double dt, bool gate);
        public float GetValue()
        {
            return _returnVal;
        }
        public Adjuster Clone()
        {
            Adjuster other = this.MemberwiseClone() as Adjuster;
            return other;
        }
        internal float _returnVal;
        public string Name { get; set; }
        public int AdjusterPointer { get; set; }
        public abstract void Dispose();
        
    }
}
