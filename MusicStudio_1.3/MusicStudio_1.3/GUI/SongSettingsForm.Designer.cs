namespace MusicStudio_1._3.GUI
{
    partial class SongSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSongName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmb_Key = new System.Windows.Forms.ComboBox();
            this.cmbTimeSignature_Numerator = new System.Windows.Forms.ComboBox();
            this.cmbTimeSignature_Denominator = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Song name:";
            // 
            // txtSongName
            // 
            this.txtSongName.Location = new System.Drawing.Point(127, 15);
            this.txtSongName.Name = "txtSongName";
            this.txtSongName.Size = new System.Drawing.Size(100, 22);
            this.txtSongName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bpm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "TimeSignature:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(127, 43);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(102, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(21, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmb_Key
            // 
            this.cmb_Key.FormattingEnabled = true;
            this.cmb_Key.Location = new System.Drawing.Point(126, 76);
            this.cmb_Key.Name = "cmb_Key";
            this.cmb_Key.Size = new System.Drawing.Size(121, 24);
            this.cmb_Key.TabIndex = 9;
            this.cmb_Key.SelectedIndexChanged += new System.EventHandler(this.cmb_Key_SelectedIndexChanged);
            // 
            // cmbTimeSignature_Numerator
            // 
            this.cmbTimeSignature_Numerator.FormattingEnabled = true;
            this.cmbTimeSignature_Numerator.Location = new System.Drawing.Point(127, 112);
            this.cmbTimeSignature_Numerator.Name = "cmbTimeSignature_Numerator";
            this.cmbTimeSignature_Numerator.Size = new System.Drawing.Size(50, 24);
            this.cmbTimeSignature_Numerator.TabIndex = 10;
            // 
            // cmbTimeSignature_Denominator
            // 
            this.cmbTimeSignature_Denominator.FormattingEnabled = true;
            this.cmbTimeSignature_Denominator.Location = new System.Drawing.Point(127, 133);
            this.cmbTimeSignature_Denominator.Name = "cmbTimeSignature_Denominator";
            this.cmbTimeSignature_Denominator.Size = new System.Drawing.Size(50, 24);
            this.cmbTimeSignature_Denominator.TabIndex = 10;
            // 
            // SongSettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 219);
            this.Controls.Add(this.cmbTimeSignature_Denominator);
            this.Controls.Add(this.cmbTimeSignature_Numerator);
            this.Controls.Add(this.cmb_Key);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.txtSongName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SongSettingsForm";
            this.Text = "SongSettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSongName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmb_Key;
        private System.Windows.Forms.ComboBox cmbTimeSignature_Numerator;
        private System.Windows.Forms.ComboBox cmbTimeSignature_Denominator;
    }
}