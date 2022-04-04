using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MusicStudio_1._3.BLL
{

    

    [XmlInclude(typeof(Eff_Reverb_0))]
    [XmlInclude(typeof(WaveAdd))]
    public abstract class SoundEffect:IDisposable
    {
        internal Instrument.GetValDelegate RequestAdjuster;

        public abstract float StepForward(double pitch, float input, double dt);
        public SoundEffect Clone()
        {
            SoundEffect other = this.MemberwiseClone() as SoundEffect;
            return other;
        }
        

        public abstract void Dispose();

        public double Pitch { get; set; }
        public string Name { get; set; }
        public int AdjusterPointer { get; set; }
        public List<Adjuster> _adjusterObjects { get; set; }
    }
}
