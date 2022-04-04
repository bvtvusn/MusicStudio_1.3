using MusicStudio_1._3.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicStudio_1._3.BLL.NoteFrequency;

namespace MusicStudio_1._3.GUI
{
    public partial class SongSettingsForm : Form
    {
        Song song;
        public SongSettingsForm(BLL.Song song)
        {
            //song.key = NoteName.Dflat;
            InitializeComponent();
            //cmb_Key.DataSource
            

            //int index = cmb_Key.Items.IndexOf(song.key);
            this.song = song;
            txtSongName.Text = song.Name;
            numericUpDown1.Value = Convert.ToDecimal(song.Bpm);


            // initialize the "key" combobox
            cmb_Key.DataSource = Enum.GetValues(typeof(NoteName));
            for (int i = 0; i < cmb_Key.Items.Count; i++)
            {
                if (cmb_Key.Items[i].ToString() == song.Key.ToString())
                {
                    cmb_Key.SelectedIndex = i;
                }
            }
            cmbTimeSignature_Numerator.DataSource = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            cmbTimeSignature_Numerator.SelectedIndex = cmbTimeSignature_Numerator.Items.IndexOf(song.TimeSignature_Numerator);
            cmbTimeSignature_Denominator.DataSource = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            cmbTimeSignature_Denominator.SelectedIndex = cmbTimeSignature_Denominator.Items.IndexOf(song.TimeSignature_Denominator);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            song.Name = txtSongName.Text;
            song.Bpm = Convert.ToDouble(numericUpDown1.Value);
            song.Key = (NoteName)cmb_Key.SelectedItem;
            song.TimeSignature_Numerator = (int)cmbTimeSignature_Numerator.SelectedItem;
            song.TimeSignature_Denominator = (int)cmbTimeSignature_Denominator.SelectedItem;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cmb_Key_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
