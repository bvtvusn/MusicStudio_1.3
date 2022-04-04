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
    public partial class SelectForm : Form
    {
        public int SelectedIndex { get; set; }
        public SelectForm(string[] files, string formQuestion, int startIndex = 0)
        {
            
            InitializeComponent();
            SelectedIndex = startIndex;
            this.Text = formQuestion;
            lblQuestion.Text = formQuestion;

            foreach (string item in files)
            {
                trwFiles.Nodes.Add(item);
            }
            if (SelectedIndex < trwFiles.Nodes.Count) trwFiles.SelectedNode = trwFiles.Nodes[SelectedIndex];
        }

        private void trwFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedIndex = e.Node.Index;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void trwFiles_DoubleClick(object sender, EventArgs e)
        {
            //SelectedIndex = e.Node.Index;
            this.DialogResult = DialogResult.OK;
        }
    }
}
