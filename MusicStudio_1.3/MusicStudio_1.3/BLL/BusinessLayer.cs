using MusicStudio_1._3.DAL;
using MusicStudio_1._3.GUI;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio_1._3.BLL
{
    
    public class BusinessLayer
    {
        private DataAccessLayer rDal;
        private Song song;
        WaveOutEvent waveOut;
        WaveOutEvent waveOut_testTone;
        public Snap snapHelper;
        InstrumentTester instrumentTest;

        public Song Song { get => song; set { song = value; RefreshSong();   } }

        public void RefreshSong()
        {
            song.EndReachedEvent += Song_EndReachedEvent;


            //waveOut.Dispose();
            //song.StepForward();
            //song = new Song();
            //waveOut = new WaveOutEvent();
            //waveOut.Stop();
            waveOut.Init(song);
        }

        internal string[] GetInstrumentList()
        {
            return rDal.GetInstrumentList();
        }

        private void Song_EndReachedEvent()
        {
            waveOut.Stop();
            waveOut_testTone.Stop();

        }

        public BusinessLayer(DataAccessLayer rDal)
        {
            this.rDal = rDal;
            snapHelper = new Snap();
            waveOut = new WaveOutEvent();

            CreateEmptySong();
            //waveOut.Init(Song);

            //NoteFrequency iuh = new NoteFrequency(61);
            
            //iuh.Frequency = 440;

            //double modu = iuh.GetNoteNum();
            //for (int i = 0; i < 12; i++)
            //{
            //    iuh.NoteVal = 60 + i;
            //    string temp = iuh.GetNoteString();
            //}

            //Snap idaho = new Snap();
            //idaho.Enable1_8 = true;
            //idaho.Enable1_4 = true;
            //idaho.Enable1_2 = true;
            //idaho.Enable1_3 = true;
            //idaho.EnableWhole = true;

            //double myTime = 1.7;
            //double myTone = 1;
            //idaho.SnapToGrid(ref myTime, ref myTone);
            //TestSaveLoadInst();

            //CreateSampleSong();
            //SaveInstruments();
            //rDal.SaveSong(Song);


            //LoadSong("Song1");
            //LoadTracks();
            //for (int i = 0; i < 500000; i++)
            //{
            //    float result = song.StepForward();
            //}
            //song.SetPlayerHead(0);

            //Song song_orig = song;
            //CreateSampleSong();
            //PlaySong();
            //waveOut = new WaveOutEvent();
            //waveOut.Init(song);
            //waveOut.Play();
            

        }

        private void CreateEmptySong()
        {
            Song = new Song();
        }

        internal Instrument LoadInstrument(string instrumentName)
        {
            return rDal.LoadInstrument(instrumentName);
        }

        private void TestSaveLoadInst()
        {
            Instrument inst = new Instrument();
            inst.Name = "testinst";
            inst.Pitch = 440;

            inst.effectObjects.Add(new Eff_Reverb_0());
            inst.adjusterObjects.Add(new Envelope(0.1, 0.1, 1, 0.1));
            inst.effectObjects[0].AdjusterPointer = 0;

            rDal.SaveInstrument(inst);
            rDal.LoadInstrument(inst.Name);
        }

        void SaveInstruments()
        {
            foreach (Track track in Song.tracks)
            {
                rDal.SaveInstrument(track.TemplateInstrument);
                //rDal.LoadInstrument(track.InstrumentName);
            }

        }

        internal void PlaySong()
        {
            Song.SetPlayerHead(0);
            for (int i = 0; i < 100; i++)
            {
                float sample = Song.StepForward();
            }

            waveOut.Play();
        }
        internal void StopSong()
        {
            waveOut.Stop();
        }

        //internal List<Note> GetNotesInInterval(double startTime, double endTime, double lowNote, double highNote)
        //{
        //    return song.SelectedTrack.Notes;
        //}

        private void LoadTracks()
        {
            foreach (Track item in Song.tracks)
            {
                item.TemplateInstrument = rDal.LoadInstrument(item.InstrumentName);
            }
        }

        //internal void Test_SaveInstrument()
        //{
        //    rDal.SaveInstrument(song.tracks[0].TemplateInstrument);
        //}

        //void LoadSong(string songPath)
        //{
        //    Song temp = rDal.LoadSong(songPath);
        //    if (temp != null) { Song = temp; }
        //}
        internal void CreateSampleSong()
        {
            Track track = new Track();
            track.TemplateInstrument = new Instrument();
            track.TemplateInstrument.Name = "DummyInstrument";
            track.TemplateInstrument.effectObjects.Add(new Eff_Reverb_0());
            track.TemplateInstrument.adjusterObjects.Add(new Envelope(0.1,0.1,1,0.1));
            track.TemplateInstrument.effectObjects[0].AdjusterPointer = 0;
            

            WaveAdd waveAdd = new WaveAdd();
            waveAdd.waveTable = new WaveTable(WaveTable.MaskType.Fourths, WaveTable.FrequencyDecay.Linear, 0.125, 5);
            waveAdd.waveTable.CalcWaveTable();
            track.TemplateInstrument.effectObjects.Add(waveAdd);
            track.TemplateInstrument.effectObjects[0].AdjusterPointer = 0;
            track.AddNote(new NoteUnit(0, 60));
            track.AddNote(new NoteUnit(0.5, 61));
            track.AddNote(new NoteUnit(1,62));
            //track.Notes.Add(new Note(1, 0.25, 1, 1760));


           
            //track.TemplateInstrument.prepare();

            Song = new Song(100);
            //song.tracks = new List<Track> { track };
            Song.AddTrack(track);
            Song.Name = "Song1";


            Track track2 = new Track();
            track2.TemplateInstrument = track.TemplateInstrument.GetNewClone();
            track2.TemplateInstrument.Name = "secondInstrument";
            //song.tracks.Add(track2);
            Song.AddTrack(track2);
            
        }

        internal void NewSong()
        {
            Song = new Song();
        }

        internal void LoadSong()
        {
            //rDal.LoadSong("Songs\\Song1.xml");
            //Song = rDal.LoadAndSelectFile();

            Song temp = rDal.LoadAndSelectFile();
            if (temp != null) { Song = temp; }
            
        }

        internal void SaveSong()
        {
            foreach (Track track in song.tracks)
            {
                rDal.SaveInstrument(track.TemplateInstrument);
            }
            rDal.SaveSong(song);
        }

        internal void InstrumentSound(Instrument instrument, double note)
        {
            bool updateOnly = false;
            if (instrumentTest != null)
            {
                if (instrument.Name == instrumentTest.inst.Name) // Same instrument. just update existing
                {
                    updateOnly = true;
                }
            }
            
            if (updateOnly) // Same instrument. just update existing
            {
                instrumentTest.Time = 0;
                instrumentTest.NoteVal = note;

                if (waveOut_testTone.PlaybackState == PlaybackState.Stopped)
                {
                    waveOut_testTone.Play();
                }
            }
            else
            {
                instrumentTest = new InstrumentTester(instrument, note);
                instrumentTest.EndReachedEvent += Song_EndReachedEvent;

                waveOut_testTone = new WaveOutEvent();
                waveOut_testTone.Init(instrumentTest);
                waveOut_testTone.Play();
            }
            
        }

        public IEnumerable<Type> GetClassChildren(Type parentType)
        {
            //Type parentType = typeof(SoundEffect);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            IEnumerable<Type> subclasses = types.Where(t => t.BaseType == parentType);
            return subclasses;
        }

        

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




    }
}
