namespace MusicStudio_1._3.GUI
{
    partial class InstrumentStudio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectInstrument = new System.Windows.Forms.Button();
            this.txtInstrumentName = new System.Windows.Forms.TextBox();
            this.lblInstrument = new System.Windows.Forms.Label();
            this.trwEffects = new System.Windows.Forms.TreeView();
            this.trwAdjusters = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnSaveInstrument = new System.Windows.Forms.Button();
            this.btnMoveEffUp = new System.Windows.Forms.Button();
            this.btnMoveEffDown = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectInstrument
            // 
            this.btnSelectInstrument.Location = new System.Drawing.Point(297, 6);
            this.btnSelectInstrument.Name = "btnSelectInstrument";
            this.btnSelectInstrument.Size = new System.Drawing.Size(75, 23);
            this.btnSelectInstrument.TabIndex = 5;
            this.btnSelectInstrument.Text = "Change";
            this.btnSelectInstrument.UseVisualStyleBackColor = true;
            this.btnSelectInstrument.Click += new System.EventHandler(this.btnSelectInstrument_Click);
            // 
            // txtInstrumentName
            // 
            this.txtInstrumentName.Location = new System.Drawing.Point(93, 6);
            this.txtInstrumentName.Name = "txtInstrumentName";
            this.txtInstrumentName.ReadOnly = true;
            this.txtInstrumentName.Size = new System.Drawing.Size(198, 22);
            this.txtInstrumentName.TabIndex = 6;
            // 
            // lblInstrument
            // 
            this.lblInstrument.AutoSize = true;
            this.lblInstrument.Location = new System.Drawing.Point(9, 9);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(78, 17);
            this.lblInstrument.TabIndex = 7;
            this.lblInstrument.Text = "Instrument:";
            // 
            // trwEffects
            // 
            this.trwEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trwEffects.Location = new System.Drawing.Point(0, 37);
            this.trwEffects.Name = "trwEffects";
            this.trwEffects.ShowRootLines = false;
            this.trwEffects.Size = new System.Drawing.Size(213, 159);
            this.trwEffects.TabIndex = 8;
            this.trwEffects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwEffects_AfterSelect);
            // 
            // trwAdjusters
            // 
            this.trwAdjusters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trwAdjusters.Location = new System.Drawing.Point(0, 37);
            this.trwAdjusters.Name = "trwAdjusters";
            this.trwAdjusters.ShowRootLines = false;
            this.trwAdjusters.Size = new System.Drawing.Size(213, 167);
            this.trwAdjusters.TabIndex = 8;
            this.trwAdjusters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwAdjusters_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(3, 36);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trwEffects);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trwAdjusters);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(242, 404);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 9;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 37);
            this.panel3.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Effect objects:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(160, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Add";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 37);
            this.panel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Adjuster objects:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(160, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 440);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblInstrument);
            this.panel1.Controls.Add(this.btnSaveInstrument);
            this.panel1.Controls.Add(this.btnSelectInstrument);
            this.panel1.Controls.Add(this.txtInstrumentName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 36);
            this.panel1.TabIndex = 11;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(318, 124);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(443, 288);
            this.propertyGrid1.TabIndex = 15;
            // 
            // btnSaveInstrument
            // 
            this.btnSaveInstrument.Location = new System.Drawing.Point(378, 6);
            this.btnSaveInstrument.Name = "btnSaveInstrument";
            this.btnSaveInstrument.Size = new System.Drawing.Size(75, 23);
            this.btnSaveInstrument.TabIndex = 5;
            this.btnSaveInstrument.Text = "Save";
            this.btnSaveInstrument.UseVisualStyleBackColor = true;
            this.btnSaveInstrument.Click += new System.EventHandler(this.btnSaveInstrument_Click);
            // 
            // btnMoveEffUp
            // 
            this.btnMoveEffUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveEffUp.Location = new System.Drawing.Point(0, 0);
            this.btnMoveEffUp.Name = "btnMoveEffUp";
            this.btnMoveEffUp.Size = new System.Drawing.Size(29, 37);
            this.btnMoveEffUp.TabIndex = 16;
            this.btnMoveEffUp.Text = "↑";
            this.btnMoveEffUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveEffUp.UseVisualStyleBackColor = true;
            this.btnMoveEffUp.Click += new System.EventHandler(this.btnMoveEffUp_Click);
            // 
            // btnMoveEffDown
            // 
            this.btnMoveEffDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveEffDown.Location = new System.Drawing.Point(0, 43);
            this.btnMoveEffDown.Name = "btnMoveEffDown";
            this.btnMoveEffDown.Size = new System.Drawing.Size(29, 37);
            this.btnMoveEffDown.TabIndex = 16;
            this.btnMoveEffDown.Text = "↓";
            this.btnMoveEffDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMoveEffDown.UseVisualStyleBackColor = true;
            this.btnMoveEffDown.Click += new System.EventHandler(this.btnMoveEffDown_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnMoveEffDown);
            this.panel4.Controls.Add(this.btnMoveEffUp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(213, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(29, 159);
            this.panel4.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button7);
            this.panel5.Controls.Add(this.button8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(213, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(29, 167);
            this.panel5.TabIndex = 17;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(0, 43);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(29, 37);
            this.button7.TabIndex = 16;
            this.button7.Text = "↓";
            this.button7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(0, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(29, 37);
            this.button8.TabIndex = 16;
            this.button8.Text = "↑";
            this.button8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // InstrumentStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 440);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Name = "InstrumentStudio";
            this.Text = "InstrumentStudio";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSelectInstrument;
        private System.Windows.Forms.TextBox txtInstrumentName;
        private System.Windows.Forms.Label lblInstrument;
        private System.Windows.Forms.TreeView trwEffects;
        private System.Windows.Forms.TreeView trwAdjusters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnSaveInstrument;
        private System.Windows.Forms.Button btnMoveEffUp;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnMoveEffDown;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}