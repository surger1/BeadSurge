namespace BeadSurge
{
    partial class ImageColor
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
            this.pnlColor = new System.Windows.Forms.Panel();
            this.btnSwap = new System.Windows.Forms.Button();
            this.plcSecond = new BeadSurge.PalletColorCombo();
            this.plcBest = new BeadSurge.PalletColorCombo();
            this.SuspendLayout();
            // 
            // pnlColor
            // 
            this.pnlColor.Location = new System.Drawing.Point(3, 3);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(59, 24);
            this.pnlColor.TabIndex = 0;
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(655, 4);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 23);
            this.btnSwap.TabIndex = 3;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // plcSecond
            // 
            this.plcSecond.Enabled = false;
            this.plcSecond.Location = new System.Drawing.Point(361, 3);
            this.plcSecond.Name = "plcSecond";
            this.plcSecond.Size = new System.Drawing.Size(287, 31);
            this.plcSecond.TabIndex = 2;
            this.plcSecond.Load += new System.EventHandler(this.plcSecond_Load);
            // 
            // plcBest
            // 
            this.plcBest.Location = new System.Drawing.Point(68, 3);
            this.plcBest.Name = "plcBest";
            this.plcBest.Size = new System.Drawing.Size(287, 31);
            this.plcBest.TabIndex = 1;
            this.plcBest.ColorChange += new System.EventHandler(this.plcBest_ColorChange);
            this.plcBest.Load += new System.EventHandler(this.plcBest_Load);
            // 
            // ImageColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.plcSecond);
            this.Controls.Add(this.plcBest);
            this.Controls.Add(this.pnlColor);
            this.Name = "ImageColor";
            this.Size = new System.Drawing.Size(739, 34);
            this.Load += new System.EventHandler(this.ImageColor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColor;
        private PalletColorCombo plcBest;
        private PalletColorCombo plcSecond;
        private System.Windows.Forms.Button btnSwap;
    }
}
