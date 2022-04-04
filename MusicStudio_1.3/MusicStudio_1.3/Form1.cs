using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicStudio_1._3.BLL;
using MusicStudio_1._3.DAL;
using MusicStudio_1._3.GUI;

namespace MusicStudio_1._3
{
    public partial class Form1 : Form
    {
        private DataAccessLayer rDal;
        private BusinessLayer rBll;
        //NoteView noteView;
        


        // MouseRelated
        

        public Form1(BusinessLayer rBll, DataAccessLayer rDal)
        {
            this.rDal = rDal;
            this.rBll = rBll;
            InitializeComponent();

            
            RefreshSong();
            


            // sync GUI and program:
            SettingChange_snap();
            
        }

        

        void RefreshSong()
        {
            // remove old stuff
            flowLayoutPanel1.Controls.Clear();

            // Add new stuff
            rBll.Song.NotesChangedEvent += Song_NotesChangedEvent;

            foreach (Track track in rBll.Song.tracks)
            {
                //flowLayoutPanel1.Controls.Add(new TrackView(rBll, track, this));
                AddTrackView(new TrackView(rBll, track, this));
            }
            UpdateSongInfo();
            UpdateTrackWindowLength();
        }
        private void Song_NotesChangedEvent()
        {
            hScrollBar1.Maximum = Convert.ToInt32(rBll.Song.songEnd * 10);
        }

        void AddTrackView(TrackView TW)
        {
            hScrollBar1.Scroll += TW.hScrollBar1_Scroll;
            flowLayoutPanel1.Controls.Add(TW);
            UpdateTrackWindowLength();
            //TW.RedrawBackground();
            //TW.track.NotesChanged += UpdateScrollbar;
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {

            rBll.PlaySong();
        }

        private void btnStopSong_Click(object sender, EventArgs e)
        {
            rBll.StopSong();
        }

        private void mnuNotes_Click(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Checked ^= true;
            SettingChange_snap();
        }

        void SettingChange_snap()
        {
            rBll.snapHelper.EnableWholeNote = mnuNotes.Checked;


            rBll.snapHelper.EnableWhole = mnu1_1Bar.Checked;


            rBll.snapHelper.Enable1_2 = mnu1_2Bar.Checked;


            rBll.snapHelper.Enable1_3 = mnu1_3Bar.Checked;
            rBll.snapHelper.Enable1_4 = mnu1_4Bar.Checked;
            rBll.snapHelper.Enable1_8 = mnu1_8Bar.Checked;
        }

        //private void btnAddTrack_Click(object sender, EventArgs e)
        //{
        //    flowLayoutPanel1.Controls.Add(new TrackView(rBll, rBll.song.SelectedTrack,this));
        //}

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            UpdateTrackWindowLength();
        }
        void UpdateTrackWindowLength()
        {
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                item.Width = flowLayoutPanel1.Width - 25;
            }
        }

        void UpdateSongInfo()
        {
            lblSongName.Text = rBll.Song.Name;
        }

        private void btnAddTrack_Click_1(object sender, EventArgs e)
        {
            Track track = new Track();
            track.TemplateInstrument = Instrument.CreateSineInstrument(); // CreateGhostInstrument();
            rBll.Song.AddTrack(track);
            //TrackView temp = new TrackView(rBll,track,this);
            //flowLayoutPanel1.Controls.Add(temp);
            AddTrackView(new TrackView(rBll, track, this));


        }

        //private Instrument CreateGhostInstrument()
        //{
        //    Instrument inst = new Instrument();
        //    inst.Name = "Ghost Instrument";
        //    inst.adjusterObjects.Add(new Envelope(0.01, 0.01, 1, 0.01));

        //    WaveAdd waveAdd = new WaveAdd();
        //    waveAdd.waveTable = new WaveTable(WaveTable.MaskType.All, WaveTable.FrequencyDecay.InverseSquare, 0.125, 1);
        //    waveAdd.waveTable.CalcWaveTable();
        //    inst.effectObjects.Add(waveAdd);
        //    inst.effectObjects[0].AdjusterPointer = 0;

        //    return inst;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTrackWindowLength();
            foreach (Control item in flowLayoutPanel1.Controls)
            {
                (item as TrackView).RedrawBackground();
            }
            
        }

        private void btnSongSettings_Click(object sender, EventArgs e)
        {
            SongSettingsForm dialog = new SongSettingsForm(rBll.Song);
            dialog.ShowDialog(this);
            UpdateSongInfo();
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rBll.SaveSong();
        }

        private void loadSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuestion();
            rBll.LoadSong();
            RefreshSong();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rBll.CreateSampleSong();
            rBll.RefreshSong();
        }

        void SaveQuestion()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save the current song?", "Save?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                rBll.SaveSong();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void newSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveQuestion();
            rBll.NewSong();
        }

        private void instrumentStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstrumentStudio form = new InstrumentStudio(rBll, rDal);
            form.Show();

        }
    }
}
