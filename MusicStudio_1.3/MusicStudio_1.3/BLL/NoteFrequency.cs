using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    public class NoteFrequency
    {
        private double noteVal = 0;
        public double NoteVal { get => noteVal; set => noteVal = value; }
        bool _nameRuleUp = true;

        public double Frequency
        {
            get { return NoteToFreq(noteVal); }
            set { NoteVal = FreqToNote(value); }
        }

        public enum NoteName
        {
            C,
            Csharp,

            Dflat,
            D,
            Dsharp,

            Eflat,
            E, 

            F,
            Fsharp,

            Gflat,
            G,
            Gsharp,

            Aflat,
            A,
            Asharp,

            Hflat,
            H
        }

        public NoteFrequency()
        {
            _nameRuleUp = true;
        }
        public NoteFrequency(double NoteVal, bool nameRuleUp = true)
        {
            this.NoteVal = NoteVal;
            _nameRuleUp = nameRuleUp;
        }

        public static double FreqToNote(double freq)
        {
            double tone = Math.Log(freq / 440, 2) * 12;
            return tone + 5 * 12;
        }

        public static double NoteToFreq(double NoteVal)
        {
            double Pitch = Math.Pow(2, (NoteVal - 5 * 12) / 12) * 440;
            return Pitch;
        }

        public void RoundNote()
        {
            noteVal = Math.Round(noteVal);
        }

        public NoteName GetNoteName()
        {
            int noteModulo = Convert.ToInt32(noteVal % 12);
            NoteName noteName;
            switch (noteModulo)
            {
                case 0:
                    noteName = NoteName.A;
                    break;
                case 1:
                    if (_nameRuleUp) noteName = NoteName.Asharp;
                    else noteName = NoteName.Hflat;
                    break;
                case 2:
                    noteName = NoteName.H;
                    break;
                case 3:
                    noteName = NoteName.C;
                    break;
                case 4:
                    if (_nameRuleUp) noteName = NoteName.Csharp;
                    else noteName = NoteName.Dflat;
                    break;
                case 5:
                    noteName = NoteName.D;
                    break;
                case 6:
                    if (_nameRuleUp) noteName = NoteName.Dsharp;
                    else noteName = NoteName.Eflat;
                    break;
                case 7:
                    noteName = NoteName.E;
                    break;
                case 8:
                    noteName = NoteName.F;
                    break;
                case 9:
                    if (_nameRuleUp) noteName = NoteName.Fsharp;
                    else noteName = NoteName.Gflat;
                    break;
                case 10:
                    noteName = NoteName.G;
                    break;
                case 11:
                    if (_nameRuleUp) noteName = NoteName.Gsharp;
                    else noteName = NoteName.Aflat;
                    break;
                default:
                    noteName = NoteName.A;
                    break;
            }
            return noteName;
        }

        public string GetNoteString()
        {
            return GetNoteName().ToString();

        }
        //public double GetNoteNum()
        //{
        //    return noteVal % 12;
        //}


        
    }
}
