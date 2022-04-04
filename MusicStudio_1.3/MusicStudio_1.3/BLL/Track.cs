using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MusicStudio_1._3.BLL
{
    public class Track
    {
        //List<Note> notes;
        private List<NoteUnit> _notes;
        
        public List<NoteUnit> Notes { get { return _notes; } }
        [XmlIgnore]
        public Instrument TemplateInstrument;
        List<NoteUnit> ActiveNotes;
        int waitingNoteIndex = 0;
        string localInstrumentName = "None";
        public event Action NotesChanged;
        
        public string InstrumentName
        {
            get
            {
                if (TemplateInstrument == null) return localInstrumentName;
                else return TemplateInstrument.Name;
            }
            set { localInstrumentName = value; } 
            
        }

        //public string __Name { get => "Placeholder"; internal set { } }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        public Track()
        {
            ActiveNotes = new List<NoteUnit>();
            _notes = new List<NoteUnit>();
            _Name = "Dafaultname";
            //NotesChanged = Action
            //testing_AddNotes();
            //testing_AddOscillator();
        }

        internal void Reset()
        {
            foreach (NoteUnit item in ActiveNotes)
            {
                item.RemovePlayInstrument();
            }
            ActiveNotes.Clear();
            waitingNoteIndex = 0;
        }



        //public void SetInstrument(Instrument instrument)
        //{
        //    TemplateInstrument = instrument;
        //}


        private void NoteChangeCleanup()
        {
            // sort notes:
            _notes = _notes.OrderBy(o => o.Start).ToList();

            // Activate notechange event

            NotesChanged?.Invoke();
            
            
        }

        public void AddNote(NoteUnit note)
        {
            _notes.Add(note);
            NoteChangeCleanup();
        }
       
        
        internal float StepForward(double songTime, double timestep)
        {
            ActivateNewNotes(songTime);

            // Play Oscillators
            float soundSample = 0;
            for (int i = ActiveNotes.Count - 1; i >= 0; i--)
            {
                soundSample += ActiveNotes[i].StepForward(songTime, timestep); // Play unfinished notes
                if (ActiveNotes[i].IsOn)
                {
                    //bool gate = ActiveNotes[i].Stop_ >= time;
                    //soundSample += ActiveNotes[i].StepForward(timestep, gate); // Play unfinished notes
                }
                else
                {
                    //ActiveNotes[i].PlayInstrument = null;
                    ActiveNotes[i].RemovePlayInstrument();
                    ActiveNotes.Remove(ActiveNotes[i]); // Remove finished notes
                }
            }

            return soundSample;
        }

        void ActivateNewNotes(double songTime)
        {
            if (_notes.Count == 0) return;
            while (true)
            {
                if (waitingNoteIndex >= _notes.Count) return;
                if (_notes[waitingNoteIndex].Start <= songTime)
                {


                    // ----------- Add a new oscillator to the list ---------------
                    //ActiveNotes.Add(new Oscillator(_notes[waitingNoteIndex]));

                    //Oscillator noteOscillator = TemplateOscillator.GetNewClone();
                    //noteOscillator.NoteData = _notes[waitingNoteIndex];
                    //ActiveNotes.Add(noteOscillator);
                    _notes[waitingNoteIndex].PlayInstrument = TemplateInstrument.GetNewClone();
                    ActiveNotes.Add(_notes[waitingNoteIndex]);
                    // --------------------------------------------------------------

                    waitingNoteIndex++;
                }
                else return;

            }
        }

        internal void MoveSelectedNotes(double time, double note)
        {
            //List<Note> notes = _notes;
            for (int i = 0; i < _notes.Count; i++)
            {
                if (_notes[i].selected)
                {
                    double dur = _notes[i].Duration_;
                    _notes[i].Start += time;
                    _notes[i].Duration_ = dur;

                    _notes[i].NoteVal += note;
                }
            }
            NoteChangeCleanup();
        }

        internal void DeselectAll()
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                Notes[i].selected = false;
            }
        }

        internal List<NoteUnit> GetNotesInInterval(double time1, double time2, double note1, double note2)
        {
            double minTime = Math.Min(time1, time2);
            double maxTime = Math.Max(time1, time2);
            double minNote = Math.Min(note1, note2);
            double maxNote = Math.Max(note1, note2);
            //internal Note GetNoteAt(double time, double note)
            //{
            //    List<Note> retrievedNotes = song.SelectedTrack.Notes.Where(
            //        x => 
            //        x.Start <= time && 
            //        x.Stop_ >= time && 
            //        Math.Abs(x.GetNoteVal() - note) <= 0.5).ToList();
            //    if (retrievedNotes.Count > 0) return retrievedNotes[0];
            //    else return null;
            //}

            List<NoteUnit> markedNotes = _notes.Where(x => x.Start < maxTime && x.Stop_ > minTime && x.NoteVal > minNote && x.NoteVal < maxNote).ToList();
            return markedNotes; // Must be completed later
        }
        internal NoteUnit GetNoteAt(double time, double note)
        {
            List<NoteUnit> retrievedNotes = Notes.Where(
                x =>
                x.Start <= time &&
                x.Stop_ >= time &&
                Math.Abs(x.GetNoteVal() - note) <= 0.5).ToList();
            if (retrievedNotes.Count > 0) return retrievedNotes[0];
            else return null;
        }

        internal void ChangeNoteLengthInSelection(double timeChange)
        {
            for (int i = 0; i < _notes.Count; i++)
            {
                if (_notes[i].selected)
                {
                    _notes[i].Duration_ += timeChange;
                }
            }
            NoteChangeCleanup();
        }
    }
}