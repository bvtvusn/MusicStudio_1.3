using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Serialization;
using static MusicStudio_1._3.BLL.NoteFrequency;

namespace MusicStudio_1._3.BLL
{
    public class Song : ISampleProvider
    {

        public List<Track> tracks;
        private int sampleRate = 44100;
        private double bpm = 100;
        private NoteName key = NoteName.C;
        private int timeSignature_Numerator = 4;
        private int timeSignature_Denominator = 4;

        double songTime = 0;
        int selectedTrack = 0;
        public double songEnd = 0;
        private string _name;

        public event Action NotesChangedEvent;
        public event Action EndReachedEvent;
        //public event Action SongChangedEvent;

        public Song(double bpm = 100, int sampleRate = 44100, NoteName Key = NoteName.C)
        {
            this.Bpm = bpm;
            this.SampleRate = sampleRate;
            this.Key = Key;
            Init();


            //Testing_CreateTrack();
            //Testing_checkWave();


            //Envelope env = new Envelope(0.1, 0.1, 0.5f, 0.1);


        }
        public Song()
        {
            Init();
        }
        public void SetPlayerHead(double time)
        {
            this.songTime = time;

            if (songTime < 0.001)
            {
                foreach (Track track in tracks)
                {
                    track.Reset();
                }
            }
        }
        void Init()
        {
            

            tracks = new List<Track>();
            WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, 1);
            //RefreshSongEnd();

        }
        private void Testing_checkWave()
        {
            //StepForward();
            float[] buffer = new float[1000];
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = StepForward();
            }
            timer.Stop();
        }

        public float StepForward()
        {
            double timestep = 1.0 / SampleRate;
            float combinedTracks = 0;
            foreach (Track track in tracks)
            {
                combinedTracks += track.StepForward(songTime, timestep);
            }

            songTime += timestep * (Bpm / 60);

            return combinedTracks;
        }

        void Testing_CreateTrack()
        {
            tracks.Add(new Track());
        }
        [XmlIgnore] // Hidden
        public WaveFormat WaveFormat { get; private set; }

        public string Name { get => _name; set { _name = value; songChanged(); } }
        private void songChanged()
        {
            //SongChangedEvent?.Invoke();
        }


        public int Read(float[] buffer, int offset, int count)
        {
            for (int i = 0; i < count; i++)
            {
                buffer[i] = StepForward();
                //buffer[i] = Convert.ToSingle(Math.Sin(i * 0.1));
            }


            if (songTime > songEnd + 1)
            {
                EndReachedEvent?.Invoke();
            }
            return count;
        }

        public Track SelectedTrack { get { return tracks[selectedTrack]; } }

        public int TimeSignature_Denominator { get => timeSignature_Denominator; set { timeSignature_Denominator = value; songChanged(); } }
        public int TimeSignature_Numerator { get => timeSignature_Numerator; set { timeSignature_Numerator = value; songChanged(); } }
        public NoteName Key { get => key; set { key = value; songChanged(); } }
        public double Bpm { get => bpm; set { bpm = value; songChanged(); } }
        public int SampleRate { get => sampleRate; set { sampleRate = value; songChanged(); } }

        internal void AddTrack(Track temp)
        {
            //Track temp = new Track();
            //temp.Name = name;
            //temp.TemplateInstrument = instrument;
            tracks.Add(temp);
            temp.NotesChanged += RefreshSongEnd;
            RefreshSongEnd();
        }
        public void RefreshSongEnd()
        {
            // Calculate Song Length
            songEnd = 0;
            foreach (Track item in tracks)
            {
                if (item.Notes.Count > 0)
                {
                    double trackEndTIme = item.Notes[item.Notes.Count - 1].Stop_;
                    if (trackEndTIme > songEnd)
                    {
                        songEnd = trackEndTIme;
                    }
                }
            }

            if (NotesChangedEvent != null)
            {
                NotesChangedEvent?.Invoke();
            }
            
        }
    }
}