namespace BeadSurge
{
    partial class Report
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblffff = new System.Windows.Forms.Label();
            this.lblGrids = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdReport = new System.Windows.Forms.SaveFileDialog();
            this.lblPixels = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInches = new System.Windows.Forms.Label();
            this.lblcm = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblcm);
            this.panel1.Controls.Add(this.lblInches);
            this.panel1.Controls.Add(this.lblPixels);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCost);
            this.panel1.Controls.Add(this.lblffff);
            this.panel1.Controls.Add(this.lblGrids);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 725);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(347, 114);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 13);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "otototot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Estimated Time";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(347, 99);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(43, 13);
            this.lblCost.TabIndex = 7;
            this.lblCost.Text = "otototot";
            // 
            // lblffff
            // 
            this.lblffff.AutoSize = true;
            this.lblffff.Location = new System.Drawing.Point(12, 99);
            this.lblffff.Name = "lblffff";
            this.lblffff.Size = new System.Drawing.Size(77, 13);
            this.lblffff.TabIndex = 6;
            this.lblffff.Text = "Estimated Cost";
            // 
            // lblGrids
            // 
            this.lblGrids.AutoSize = true;
            this.lblGrids.Location = new System.Drawing.Point(350, 41);
            this.lblGrids.Name = "lblGrids";
            this.lblGrids.Size = new System.Drawing.Size(43, 13);
            this.lblGrids.TabIndex = 5;
            this.lblGrids.Text = "otototot";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(350, 24);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "otototot";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Grids Used";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Beads";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(583, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportReportToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // exportReportToolStripMenuItem
            // 
            this.exportReportToolStripMenuItem.Name = "exportReportToolStripMenuItem";
            this.exportReportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportReportToolStripMenuItem.Text = "Export Report";
            this.exportReportToolStripMenuItem.Click += new System.EventHandler(this.exportReportToolStripMenuItem_Click);
            // 
            // lblPixels
            // 
            this.lblPixels.AutoSize = true;
            this.lblPixels.Location = new System.Drawing.Point(350, 54);
            this.lblPixels.Name = "lblPixels";
            this.lblPixels.Size = new System.Drawing.Size(43, 13);
            this.lblPixels.TabIndex = 12;
            this.lblPixels.Text = "otototot";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dimensions";
            // 
            // lblInches
            // 
            this.lblInches.AutoSize = true;
            this.lblInches.Location = new System.Drawing.Point(350, 67);
            this.lblInches.Name = "lblInches";
            this.lblInches.Size = new System.Drawing.Size(43, 13);
            this.lblInches.TabIndex = 13;
            this.lblInches.Text = "otototot";
            // 
            // lblcm
            // 
            this.lblcm.AutoSize = true;
            this.lblcm.Location = new System.Drawing.Point(350, 78);
            this.lblcm.Name = "lblcm";
            this.lblcm.Size = new System.Drawing.Size(43, 13);
            this.lblcm.TabIndex = 14;
            this.lblcm.Text = "otototot";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 725);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Report";
            this.Text = "Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblGrids;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblffff;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportReportToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdReport;
        private System.Windows.Forms.Label lblcm;
        private System.Windows.Forms.Label lblInches;
        private System.Windows.Forms.Label lblPixels;
        private System.Windows.Forms.Label label5;

    }
}