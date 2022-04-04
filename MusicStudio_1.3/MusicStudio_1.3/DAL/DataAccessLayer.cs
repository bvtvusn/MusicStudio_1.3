using MusicStudio_1._3.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicStudio_1._3.DAL
{
    public class DataAccessLayer
    {
        string songDirName = "Songs";
        string instrumentDirName = "Instruments";
        public void SaveInstrument(Instrument instrument)
        {
            Directory.CreateDirectory(instrumentDirName);
            string filename = instrumentDirName + "\\" + instrument.Name + ".xml";
            using (FileStream fs = File.Create(filename))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Instrument));
                xs.Serialize(fs, instrument);
            }
        }

        internal Instrument LoadInstrument(string instrumentName)
        {
            string filename = instrumentDirName + "\\" + instrumentName + ".xml";
            using (StreamReader reader = new StreamReader(filename))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Instrument));
                Instrument temp = xs.Deserialize(reader) as Instrument;
                temp.Name = instrumentName;

                return temp;
            }
        }

        internal string[] GetInstrumentList()
        {
                string[] paths = Directory.GetFiles(instrumentDirName);
            for (int i = 0; i < paths.Length; i++)
            {
                paths[i] = Path.GetFileNameWithoutExtension(paths[i]);
            }
            return paths;
        }

        public Song LoadAndSelectFile()
        {
OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = songDirName,
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //filename = openFileDialog1.FileName;
                 Song temp = LoadSong(openFileDialog1.FileName);
                return temp;
            }
            return null;
        }
        internal Song LoadSong(string songPath)
        {
            //string filename = "";
            




            Song resultSong;
            //string filename = songDirName + "\\" + songName + ".xml";
            using (StreamReader reader = new StreamReader(songPath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Song));
                resultSong = xs.Deserialize(reader) as Song;
            }

            foreach (Track track in resultSong.tracks)
            {
                Instrument loadedInstrument = LoadInstrument(track.InstrumentName);
                track.TemplateInstrument = loadedInstrument;
            }
            resultSong.RefreshSongEnd();
            return resultSong;
        }

        public void SaveSong(Song song)
        {
            Directory.CreateDirectory(songDirName);
            string filename = songDirName + "\\" + song.Name + ".xml";
            using (FileStream fs = File.Create(filename))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Song));
                xs.Serialize(fs, song);
            }
        }
    }
}
