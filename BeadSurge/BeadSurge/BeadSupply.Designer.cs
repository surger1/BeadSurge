namespace BeadSurge
{
    partial class BeadSupply
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSupply = new System.Windows.Forms.Label();
            this.lblOwned = new System.Windows.Forms.Label();
            this.lblUsed = new System.Windows.Forms.Label();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.nudAdd = new System.Windows.Forms.NumericUpDown();
            this.plcColour = new BeadSurge.PalletColorCombo();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSupply
            // 
            this.lblSupply.AutoSize = true;
            this.lblSupply.Location = new System.Drawing.Point(323, 13);
            this.lblSupply.Name = "lblSupply";
            this.lblSupply.Size = new System.Drawing.Size(39, 13);
            this.lblSupply.TabIndex = 1;
            this.lblSupply.Text = "Supply";
            // 
            // lblOwned
            // 
            this.lblOwned.AutoSize = true;
            this.lblOwned.Location = new System.Drawing.Point(427, 13);
            this.lblOwned.Name = "lblOwned";
            this.lblOwned.Size = new System.Drawing.Size(41, 13);
            this.lblOwned.TabIndex = 2;
            this.lblOwned.Text = "Owned";
            // 
            // lblUsed
            // 
            this.lblUsed.AutoSize = true;
            this.lblUsed.Location = new System.Drawing.Point(525, 13);
            this.lblUsed.Name = "lblUsed";
            this.lblUsed.Size = new System.Drawing.Size(32, 13);
            this.lblUsed.TabIndex = 3;
            this.lblUsed.Text = "Used";
            // 
            // chkUse
            // 
            this.chkUse.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUse.AutoSize = true;
            this.chkUse.Checked = true;
            this.chkUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUse.Location = new System.Drawing.Point(737, 8);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(56, 23);
            this.chkUse.TabIndex = 4;
            this.chkUse.Text = "Enabled";
            this.chkUse.UseVisualStyleBackColor = true;
            this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
            // 
            // nudAdd
            // 
            this.nudAdd.Increment = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nudAdd.Location = new System.Drawing.Point(602, 11);
            this.nudAdd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAdd.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudAdd.Name = "nudAdd";
            this.nudAdd.Size = new System.Drawing.Size(120, 20);
            this.nudAdd.TabIndex = 5;
            this.nudAdd.ValueChanged += new System.EventHandler(this.nudAdd_ValueChanged);
            this.nudAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDown1_KeyPress);
            // 
            // plcColour
            // 
            this.plcColour.Enabled = false;
            this.plcColour.Location = new System.Drawing.Point(4, 4);
            this.plcColour.Name = "plcColour";
            this.plcColour.Size = new System.Drawing.Size(287, 31);
            this.plcColour.TabIndex = 0;
            // 
            // BeadSupply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudAdd);
            this.Controls.Add(this.chkUse);
            this.Controls.Add(this.lblUsed);
            this.Controls.Add(this.lblOwned);
            this.Controls.Add(this.lblSupply);
            this.Controls.Add(this.plcColour);
            this.Name = "BeadSupply";
            this.Size = new System.Drawing.Size(818, 40);
            this.Load += new System.EventHandler(this.BeadSupply_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PalletColorCombo plcColour;
        private System.Windows.Forms.Label lblSupply;
        private System.Windows.Forms.Label lblOwned;
        private System.Windows.Forms.Label lblUsed;
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.NumericUpDown nudAdd;

    }
}
