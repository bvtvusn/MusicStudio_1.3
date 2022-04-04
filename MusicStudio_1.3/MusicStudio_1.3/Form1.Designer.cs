namespace MusicStudio_1._3
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnStopSong = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNotes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu1_3Bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu1_4Bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu1_8Bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu1_2Bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu1_1Bar = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSongSettings = new System.Windows.Forms.Button();
            this.lblSongName = new System.Windows.Forms.Label();
            this.instrumentStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "btnPlaySound";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnStopSong
            // 
            this.btnStopSong.Location = new System.Drawing.Point(37, 42);
            this.btnStopSong.Name = "btnStopSong";
            this.btnStopSong.Size = new System.Drawing.Size(75, 23);
            this.btnStopSong.TabIndex = 2;
            this.btnStopSong.Text = "Stop";
            this.btnStopSong.UseVisualStyleBackColor = true;
            this.btnStopSong.Click += new System.EventHandler(this.btnStopSong_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.snapToGridToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(925, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSongToolStripMenuItem,
            this.loadSongToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newSongToolStripMenuItem
            // 
            this.newSongToolStripMenuItem.Name = "newSongToolStripMenuItem";
            this.newSongToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.newSongToolStripMenuItem.Text = "New Song";
            this.newSongToolStripMenuItem.Click += new System.EventHandler(this.newSongToolStripMenuItem_Click);
            // 
            // loadSongToolStripMenuItem
            // 
            this.loadSongToolStripMenuItem.Name = "loadSongToolStripMenuItem";
            this.loadSongToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.loadSongToolStripMenuItem.Text = "Load Song";
            this.loadSongToolStripMenuItem.Click += new System.EventHandler(this.loadSongToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.saveToolStripMenuItem.Text = "Save Song";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instrumentStudioToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // snapToGridToolStripMenuItem
            // 
            this.snapToGridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNotes,
            this.mnu1_3Bar,
            this.mnu1_4Bar,
            this.mnu1_8Bar,
            this.mnu1_2Bar,
            this.mnu1_1Bar});
            this.snapToGridToolStripMenuItem.Name = "snapToGridToolStripMenuItem";
            this.snapToGridToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.snapToGridToolStripMenuItem.Text = "Snap To Grid";
            // 
            // mnuNotes
            // 
            this.mnuNotes.Checked = true;
            this.mnuNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuNotes.Name = "mnuNotes";
            this.mnuNotes.Size = new System.Drawing.Size(132, 26);
            this.mnuNotes.Text = "Notes";
            this.mnuNotes.Click += new System.EventHandler(this.mnuNotes_Click);
            // 
            // mnu1_3Bar
            // 
            this.mnu1_3Bar.Name = "mnu1_3Bar";
            this.mnu1_3Bar.Size = new System.Drawing.Size(132, 26);
            this.mnu1_3Bar.Text = "1/3 Bar";
            this.mnu1_3Bar.Click += new System.EventHandler(this.mnuNotes_Click);
            // 
            // mnu1_4Bar
            // 
            this.mnu1_4Bar.Checked = true;
            this.mnu1_4Bar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnu1_4Bar.Name = "mnu1_4Bar";
            this.mnu1_4Bar.Size = new System.Drawing.Size(132, 26);
            this.mnu1_4Bar.Text = "1/4 Bar";
            this.mnu1_4Bar.Click += new System.EventHandler(this.mnuNotes_Click);
            // 
            // mnu1_8Bar
            // 
            this.mnu1_8Bar.Name = "mnu1_8Bar";
            this.mnu1_8Bar.Size = new System.Drawing.Size(132, 26);
            this.mnu1_8Bar.Text = "1/8 Bar";
            this.mnu1_8Bar.Click += new System.EventHandler(this.mnuNotes_Click);
            // 
            // mnu1_2Bar
            // 
            this.mnu1_2Bar.Name = "mnu1_2Bar";
            this.mnu1_2Bar.Size = new System.Drawing.Size(132, 26);
            this.mnu1_2Bar.Text = "1/2 Bar";
            this.mnu1_2Bar.Click += new System.EventHandler(this.mnuNotes_Click);
            // 
            // mnu1_1Bar
            // 
            this.mnu1_1Bar.Name = "mnu1_1Bar";
            this.mnu1_1Bar.Size = new System.Drawing.Size(132, 26);
            this.mnu1_1Bar.Text = "1/1 Bar";
            this.mnu1_1Bar.Click += new System.EventHandler(this.mnuNotes_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(725, 358);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Location = new System.Drawing.Point(37, 71);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(75, 23);
            this.btnAddTrack.TabIndex = 0;
            this.btnAddTrack.Text = "AddTrack";
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnAddTrack);
            this.panel1.Controls.Add(this.btnStopSong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(725, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 415);
            this.panel1.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.hScrollBar1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 415);
            this.panel2.TabIndex = 6;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 394);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(725, 21);
            this.hScrollBar1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSongSettings);
            this.panel3.Controls.Add(this.lblSongName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(725, 36);
            this.panel3.TabIndex = 5;
            // 
            // btnSongSettings
            // 
            this.btnSongSettings.Location = new System.Drawing.Point(434, 4);
            this.btnSongSettings.Name = "btnSongSettings";
            this.btnSongSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSongSettings.TabIndex = 1;
            this.btnSongSettings.Text = "btnSongSettings";
            this.btnSongSettings.UseVisualStyleBackColor = true;
            this.btnSongSettings.Click += new System.EventHandler(this.btnSongSettings_Click);
            // 
            // lblSongName
            // 
            this.lblSongName.AutoSize = true;
            this.lblSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSongName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSongName.Location = new System.Drawing.Point(228, 8);
            this.lblSongName.Name = "lblSongName";
            this.lblSongName.Size = new System.Drawing.Size(116, 25);
            this.lblSongName.TabIndex = 0;
            this.lblSongName.Text = "Testsong_1";
            // 
            // instrumentStudioToolStripMenuItem
            // 
            this.instrumentStudioToolStripMenuItem.Name = "instrumentStudioToolStripMenuItem";
            this.instrumentStudioToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.instrumentStudioToolStripMenuItem.Text = "Instrument Studio";
            this.instrumentStudioToolStripMenuItem.Click += new System.EventHandler(this.instrumentStudioToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(925, 443);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStopSong;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snapToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNotes;
        private System.Windows.Forms.ToolStripMenuItem mnu1_4Bar;
        private System.Windows.Forms.ToolStripMenuItem mnu1_8Bar;
        private System.Windows.Forms.ToolStripMenuItem mnu1_3Bar;
        private System.Windows.Forms.ToolStripMenuItem mnu1_2Bar;
        private System.Windows.Forms.ToolStripMenuItem mnu1_1Bar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSongSettings;
        private System.Windows.Forms.Label lblSongName;
        private System.Windows.Forms.ToolStripMenuItem newSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem instrumentStudioToolStripMenuItem;
    }
}

