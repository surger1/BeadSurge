namespace BeadSurge
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.finishProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pegsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beadManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editImagePalletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beadSurgeSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssColour = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.picSprite = new System.Windows.Forms.PictureBox();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.flipHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.palletToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.cmbZoom});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1395, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.importFromClipboardToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripSeparator3,
            this.finishProjectToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importToolStripMenuItem.Text = "Import From File";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // importFromClipboardToolStripMenuItem
            // 
            this.importFromClipboardToolStripMenuItem.Name = "importFromClipboardToolStripMenuItem";
            this.importFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importFromClipboardToolStripMenuItem.Text = "Import From Clipboard";
            this.importFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.importFromClipboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem1.Text = "Export Pattern";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // finishProjectToolStripMenuItem
            // 
            this.finishProjectToolStripMenuItem.Name = "finishProjectToolStripMenuItem";
            this.finishProjectToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.finishProjectToolStripMenuItem.Text = "Finish Project";
            this.finishProjectToolStripMenuItem.Click += new System.EventHandler(this.finishProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem1,
            this.imageToolStripMenuItem1,
            this.beadManagmentToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click_1);
            // 
            // reportToolStripMenuItem1
            // 
            this.reportToolStripMenuItem1.Name = "reportToolStripMenuItem1";
            this.reportToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.reportToolStripMenuItem1.Text = "Image Report";
            this.reportToolStripMenuItem1.Click += new System.EventHandler(this.reportToolStripMenuItem1_Click);
            // 
            // imageToolStripMenuItem1
            // 
            this.imageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pegsToolStripMenuItem,
            this.gridToolStripMenuItem,
            this.flipHorizontalToolStripMenuItem});
            this.imageToolStripMenuItem1.Name = "imageToolStripMenuItem1";
            this.imageToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.imageToolStripMenuItem1.Text = "Image";
            // 
            // pegsToolStripMenuItem
            // 
            this.pegsToolStripMenuItem.Name = "pegsToolStripMenuItem";
            this.pegsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pegsToolStripMenuItem.Text = "Pegs";
            this.pegsToolStripMenuItem.Click += new System.EventHandler(this.pegsToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // beadManagmentToolStripMenuItem
            // 
            this.beadManagmentToolStripMenuItem.Name = "beadManagmentToolStripMenuItem";
            this.beadManagmentToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.beadManagmentToolStripMenuItem.Text = "Bead Managment";
            this.beadManagmentToolStripMenuItem.Click += new System.EventHandler(this.beadManagmentToolStripMenuItem_Click);
            // 
            // palletToolStripMenuItem
            // 
            this.palletToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editImagePalletToolStripMenuItem});
            this.palletToolStripMenuItem.Name = "palletToolStripMenuItem";
            this.palletToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.palletToolStripMenuItem.Text = "Pallet";
            // 
            // editImagePalletToolStripMenuItem
            // 
            this.editImagePalletToolStripMenuItem.Name = "editImagePalletToolStripMenuItem";
            this.editImagePalletToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.editImagePalletToolStripMenuItem.Text = "Edit Image Pallet";
            this.editImagePalletToolStripMenuItem.Click += new System.EventHandler(this.editImagePalletToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beadSurgeSiteToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // beadSurgeSiteToolStripMenuItem
            // 
            this.beadSurgeSiteToolStripMenuItem.Name = "beadSurgeSiteToolStripMenuItem";
            this.beadSurgeSiteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.beadSurgeSiteToolStripMenuItem.Text = "Bead Surge Site";
            this.beadSurgeSiteToolStripMenuItem.Click += new System.EventHandler(this.beadSurgeSiteToolStripMenuItem_Click);
            // 
            // cmbZoom
            // 
            this.cmbZoom.Items.AddRange(new object[] {
            "4",
            "8",
            "12",
            "16",
            "20",
            "24",
            "32"});
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Size = new System.Drawing.Size(121, 23);
            this.cmbZoom.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssColour});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1395, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssColour
            // 
            this.tssColour.Name = "tssColour";
            this.tssColour.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlDraw
            // 
            this.pnlDraw.AutoScroll = true;
            this.pnlDraw.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlDraw.Controls.Add(this.picSprite);
            this.pnlDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDraw.Location = new System.Drawing.Point(0, 27);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(1395, 613);
            this.pnlDraw.TabIndex = 2;
            this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
            // 
            // picSprite
            // 
            this.picSprite.Location = new System.Drawing.Point(3, 3);
            this.picSprite.Name = "picSprite";
            this.picSprite.Size = new System.Drawing.Size(736, 406);
            this.picSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSprite.TabIndex = 0;
            this.picSprite.TabStop = false;
            this.picSprite.Click += new System.EventHandler(this.picSprite_Click);
            this.picSprite.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picSprite_MouseDoubleClick);
            this.picSprite.MouseHover += new System.EventHandler(this.picSprite_MouseHover);
            this.picSprite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picSprite_MouseMove);
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 500;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // sfdImage
            // 
            this.sfdImage.DefaultExt = "png";
            // 
            // flipHorizontalToolStripMenuItem
            // 
            this.flipHorizontalToolStripMenuItem.Name = "flipHorizontalToolStripMenuItem";
            this.flipHorizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.flipHorizontalToolStripMenuItem.Text = "FlipHorizontal";
            this.flipHorizontalToolStripMenuItem.Click += new System.EventHandler(this.flipHorizontalToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 662);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Bead Surge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlDraw.ResumeLayout(false);
            this.pnlDraw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem palletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromClipboardToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.PictureBox picSprite;
        private System.Windows.Forms.ToolStripComboBox cmbZoom;
        private System.Windows.Forms.ToolStripMenuItem editImagePalletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tssColour;
        private System.Windows.Forms.OpenFileDialog ofdImage;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pegsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beadManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beadSurgeSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontalToolStripMenuItem;
    }
}

