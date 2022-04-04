using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicStudio_1._3.BLL;

namespace MusicStudio_1._3.GUI
{
    public partial class TrackView : UserControl
    {
        BusinessLayer rBll;
        public Track track;
        NoteView noteView;
        
        public TrackView(BusinessLayer rBll, Track track, Form1 form1)
        {
            InitializeComponent();


            //this.lblTitle.Text = "Name: " + track.Name + " Instrument: " + track.InstrumentName;
            

            //this.Parent.Parent
            this.rBll = rBll;
            this.track = track;
            UpdateTitle();
            noteView = new NoteView(rBll, track, form1);

            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(noteView.PictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(noteView.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(noteView.pictureBox1_MouseUp);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(noteView.pictureBox1_MouseDown);


            // Center scrolling at first note
            double noteStartVal = 60;
            if (track.Notes.Count > 0)
            {
                noteStartVal = track.Notes[0].NoteVal;
            }
            vScrollBar1.Value = vScrollBar1.Maximum - (int)noteStartVal;
            noteView.view_centerTone = noteStartVal;
            pictureBox1.Invalidate();

        }

        void UpdateTitle()
        {
            this.lblTitle.Text = "Name: " + track.Name + " Instrument: " + track.InstrumentName;
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {

            RedrawBackground();
        }

        public void RedrawBackground()
        {
            if (noteView != null)
            {
                pictureBox1.BackgroundImage = noteView.CreateBackground(pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TrackDataForm dialog = new TrackDataForm(track,rBll);

            
            DialogResult dr = dialog.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                dialog.Close();
            }
            else if (dr == DialogResult.OK)
            {
                dialog.Close();
                //track.Name = dialog.TrackName;
                UpdateTitle();

                //track.TemplateInstrument = dialog.Instrument;
            }
            else if ( dr == DialogResult.Abort)
            {
                dialog.Close();

                rBll.Song.tracks.Remove(track);
                this.Parent.Controls.Remove(this);
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            noteView.view_centerTone = (sender as VScrollBar).Maximum - e.NewValue;
            pictureBox1.Invalidate();
        }

        public void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            noteView.view_StartTime = (sender as HScrollBar).Value / 10.0;
            pictureBox1.Invalidate();
        }

        
    }
}
