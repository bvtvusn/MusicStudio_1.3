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

namespace MusicStudio_1._3.GUI
{
    public partial class TrackDataForm : Form
    {
        BusinessLayer rBll;
        Track track;
        public string TrackName { get { return txtTrackName.Text; }  }
        public Instrument Instrument { get { return (Instrument)comboBox1.SelectedValue; } }

        public TrackDataForm(Track track, BusinessLayer rBll)
        {
            InitializeComponent();
            this.rBll = rBll;
            this.track = track;

            string[] instruments = rBll.GetInstrumentList();
            comboBox1.DataSource = instruments;
            txtTrackName.Text = track.Name;

            for (int i = 0; i < instruments.Length; i++)
            {
                if (instruments[i] == track.InstrumentName) comboBox1.SelectedIndex = i;
            }
            //comboBox1.SelectedValue = track.InstrumentName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            track.TemplateInstrument = rBll.LoadInstrument((string)comboBox1.SelectedValue);
            track.Name = txtTrackName.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
