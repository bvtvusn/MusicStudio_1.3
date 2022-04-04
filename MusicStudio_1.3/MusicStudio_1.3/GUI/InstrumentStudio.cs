using MusicStudio_1._3.BLL;
using MusicStudio_1._3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicStudio_1._3.GUI
{
    public partial class InstrumentStudio : Form
    {
        BusinessLayer rBll;

        DataAccessLayer rDal;
        Instrument instrument;
        public InstrumentStudio(BusinessLayer rBll, DataAccessLayer rDal )
        {
            this.rBll = rBll;
            this.rDal = rDal;

            InitializeComponent();


            //cboFiles.DataSource = 
            //    string[] filenames = rDal.GetInstrumentList();
            //foreach (string item in filenames)
            //{
            //    trwFiles.Nodes.Add(item);
            //}
            
        }

        private void btnSelectInstrument_Click(object sender, EventArgs e)
        {
            string[] filenames = rDal.GetInstrumentList();
            //foreach (string item in filenames)
            //{
            //    trwFiles.Nodes.Add(item);
            //}
            int currentIndex = 0;
            if (instrument != null)
            {
                currentIndex = Array.IndexOf(filenames, instrument.Name);
            }
            


            SelectForm form = new SelectForm(filenames, "Select Instrument", currentIndex);
            DialogResult res = form.ShowDialog() ;
            if (res == DialogResult.OK) {
                string filename = filenames[form.SelectedIndex];
                Instrument instr = rDal.LoadInstrument(filename);
                SetNewInstrument(instr);
            }

        }

        void SetNewInstrument(Instrument newInstrument)
        {
            instrument = newInstrument;
            txtInstrumentName.Text = newInstrument.Name;

            trwEffects.Nodes.Clear();
            foreach (SoundEffect item in newInstrument.effectObjects)
            {
                string listitem = item.Name + " (" + item.GetType().Name + ")";
                trwEffects.Nodes.Add(listitem);
            }
            trwAdjusters.Nodes.Clear();
            foreach (Adjuster item in newInstrument.adjusterObjects)
            {
                string listitem = item.Name + " (" + item.GetType().Name + ")";
                trwAdjusters.Nodes.Add(listitem);
            }

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void trwEffects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            trwAdjusters.SelectedNode = null;
            SoundEffect d = instrument.effectObjects[e.Node.Index];

            propertyGrid1.SelectedObject = d;

            //switch (d)
            //{
            //    case Eff_Reverb_0 r:
                    
            //        break;
            //    case WaveAdd r:

            //        break;

            //    default:
            //        break;
            //}
        }

        private void trwAdjusters_AfterSelect(object sender, TreeViewEventArgs e)
        {
            trwEffects.SelectedNode = null;
            Adjuster d = instrument.adjusterObjects[e.Node.Index];
            

            propertyGrid1.SelectedObject = d;
        }

        private void btnSaveInstrument_Click(object sender, EventArgs e)
        {
            rDal.SaveInstrument(instrument);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IEnumerable<Type> subclasses = rBll.GetClassChildren(typeof(SoundEffect));
            string[] TypeNames = new string[subclasses.Count()];
            for (int i = 0; i < TypeNames.Length; i++)
            {
                TypeNames[i] = subclasses.ElementAt(i).Name;
            }


            SelectForm selectForm = new SelectForm(TypeNames, "Select type");
            DialogResult res = selectForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                Type selType = subclasses.ElementAt(selectForm.SelectedIndex);

                SoundEffect instance = (SoundEffect)Activator.CreateInstance(selType);

                instrument.effectObjects.Add(instance);

                SetNewInstrument(instrument);
            }

        }

        private void btnMoveEffUp_Click(object sender, EventArgs e)
        {
            MoveEffectItem(false);

            //TreeNode temp = trwEffects.SelectedNode;
            //MoveItem(instrument.effectObjects, trwEffects.SelectedNode.Index, false);
            //SetNewInstrument(instrument);
            ////trwEffects.SelectedNode = trwEffects.Nodes[temp]; // = temp;
            //trwEffects.SelectedNode = temp;
        }
        void MoveItem<T>(IList<T> list, int startindex, bool moveAway)
        {
            int direction =  moveAway ? 1 : -1;
            int newPos = startindex + direction;
            if (newPos < 0 || newPos >= list.Count) return;

            T temp = list[startindex];
            list[startindex] = list[newPos];
            list[newPos] = temp;
        }

        void MoveEffectItem( bool moveAway)
        {
            //instrument.effectObjects
            int startindex = trwEffects.SelectedNode.Index;
            int direction = moveAway ? 1 : -1;
            int newPos = startindex + direction;
            if (newPos < 0 || newPos >= instrument.effectObjects.Count) return;

            SoundEffect temp = instrument.effectObjects[startindex];
            instrument.effectObjects[startindex] = instrument.effectObjects[newPos];
            instrument.effectObjects[newPos] = temp;

            SetNewInstrument(instrument);
            trwEffects.SelectedNode = trwEffects.Nodes[newPos];
        }

        private void btnMoveEffDown_Click(object sender, EventArgs e)
        {
            MoveEffectItem(true);
            //int temp = trwEffects.SelectedNode.Index +1;
            //MoveItem(instrument.effectObjects, trwEffects.SelectedNode.Index, true);
            //SetNewInstrument(instrument);
            //trwEffects.SelectedNode = trwEffects.Nodes[temp]; // = temp;

            //MoveItem(instrument.effectObjects, trwEffects.SelectedNode.Index, false);
            //SetNewInstrument(instrument);
        }
    }
}
