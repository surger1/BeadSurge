using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeadSurge
{
    public partial class Form1 : Form
    {
        Pallet m_BasePallet;
        BeadImage m_Image;
        Bitmap m_OriginalImage;
        PalletForm pal;
        BeadManagement beadManagment;
        Report rep;
        Import m_Import;
        Color? m_flashColor;
        bool m_GridLines = true;
        bool m_FlipHorizontal = false;
        bool m_Pegs = true;
        bool m_OriginalColor = false;
        DateTime start;
        Color IgnoreColor;

        public Form1()
        {
            Paint += new PaintEventHandler(OnPaint);
            MouseWheel += new MouseEventHandler(OnMouseWheel);
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            cmbZoom.SelectedIndex = 1;
            m_BasePallet = new Pallet();
            gridToolStripMenuItem.Checked = m_GridLines;
            pegsToolStripMenuItem.Checked = m_Pegs;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pal != null)
            {
                pal.Close();
                
            }
            if (ofdImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Bitmap test = new Bitmap(ofdImage.FileName);
                    m_Import = new Import(test);
                    m_Import.ImagePicked += Picked;
                    m_Import.Show();
                }
                catch
                {
                    MessageBox.Show(this, "Not a Valid Picture", "I'm not good with computer");
                }
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void OnMouseWheel(Object sender, MouseEventArgs e)
        {

        }

        void OnPaint(Object sender, PaintEventArgs e)
        {

        }

        void Picked(Object sender, EventArgs e)
        {
            if (pal != null)
            {
                pal.Close();
            }
            IgnoreColor = m_Import.BackgroundColor;
            m_OriginalImage = m_Import.Output;
            m_BasePallet.ImportPallet(m_OriginalImage);
            ProcessImage();
        }

        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {

        }

        private void importFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                m_Import = new Import((Bitmap)Clipboard.GetImage());
                m_Import.ImagePicked += Picked;
                m_Import.Show();
            }
        }

        

        private void ProcessImage()
        {
            if (m_OriginalImage != null)
            {
                m_Image = new BeadImage(m_BasePallet.MorphToPallet(m_OriginalImage,IgnoreColor,m_OriginalColor), Convert.ToInt32(cmbZoom.SelectedItem.ToString()),false,m_Pegs,m_GridLines,m_flashColor,IgnoreColor,m_FlipHorizontal);
                picSprite.Image = m_Image.PostProcess;
                start = DateTime.Now;
                //Clipboard.SetImage(picSprite.Image); 
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

                ProcessImage();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PalletChanged(object sender, EventArgs e)
        {
            ProcessImage();
        }


        private void editImagePalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pal != null)
            {
                pal.Close();
            }
            pal = new PalletForm(m_BasePallet);
            pal.ColorChange += PalletChanged;
            pal.Show();
        }

        private void managmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void finishProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                Dictionary<Colour, int> m_Colours = new Dictionary<Colour, int>();
                Dictionary<Color, Colour> m_ColorToColour = new Dictionary<Color, Colour>();
                for (int i = 0; i < m_BasePallet.FoundMatches.Keys.Count; ++i)
                {
                    if (!m_Colours.ContainsKey(m_BasePallet.FoundMatches.Values.ElementAt(i).BestMatch))
                    {
                        m_Colours.Add(m_BasePallet.FoundMatches.Values.ElementAt(i).BestMatch, 0);
                        m_ColorToColour.Add(m_BasePallet.FoundMatches.Values.ElementAt(i).BestMatch.Color, m_BasePallet.FoundMatches.Values.ElementAt(i).BestMatch);
                    }
                }
                Color ignore = m_Image.Image.GetPixel(0, 0);
                for (int x = 0; x < m_Image.Image.Width; ++x)
                {
                    for (int y = 0; y < m_Image.Image.Height; ++y)
                    {
                        Color col = m_Image.Image.GetPixel(x, y);
                        if (col != ignore)
                        {
                            m_Colours[m_ColorToColour[col]]++;
                        }

                    }
                }

                for (int i = 0; i < m_Colours.Keys.Count; ++i)
                {
                    m_BasePallet.UpdateColour(m_Colours.Keys.ElementAt(i), m_Colours.Values.ElementAt(i));
                }
                m_BasePallet.Save();

                string time = String.Format("{0:t}", (DateTime.Now - start));
                time = time.Remove(time.LastIndexOf('.'));

                MessageBox.Show("Hooray! this project took roughly: " + time, "Hooray");
            }
        }

        private void picSprite_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void picSprite_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_OriginalImage != null && m_Image != null)
            {
                Colour col = m_BasePallet.ColorToColour(m_Image.MouseColor(e.X, e.Y));
                if (col != null)
                {
                    tssColour.Text = col.Name;
                    tssColour.BackColor = col.Color;
                    tssColour.Size = new Size(48, 17);
                    tssColour.ForeColor = Color.Black;
                    if (col.Color.GetBrightness() < 0.33f)
                    {
                        tssColour.ForeColor = Color.White;
                    }
                }
                else
                {
                    tssColour.Text = "";
                }
            }
        }

        private void picSprite_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (m_OriginalImage != null && tssColour.Text != "")
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    m_flashColor = null;
                    m_Image.Flash = null; 
                    if (m_Image != null)
                    {
                        m_Image.Highlighted = false;
                    }
                    tmr.Stop();
                    picSprite.Image = m_Image.Isolate(e.X, e.Y);
                }
                else
                {
                    Colour temp = m_BasePallet.ColorToColour(m_Image.MouseColor(e.X, e.Y));
                    if (temp == null)
                    {
                        m_flashColor = null;
                        m_Image.Highlighted = false;
                        tmr.Stop();
                    }
                    else
                    {

                        m_flashColor = temp.Color;
                        tmr.Start();
                    }
                    ProcessImage();
                }
            }
            else
            {
                m_flashColor = null;
                if (m_Image != null)
                {
                    m_Image.Highlighted = false;
                }
                tmr.Stop();
                ProcessImage();
            }
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                if (rep != null)
                {
                    rep.Close();

                }
                rep = new Report(m_Image.Image, m_BasePallet);
                rep.Show();
            }
        }

        private void beadManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (beadManagment != null)
            {
                beadManagment.Close();
            }
            beadManagment = new BeadManagement(m_BasePallet);
            beadManagment.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void pegsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                m_Pegs = !m_Pegs;
                pegsToolStripMenuItem.Checked = m_Pegs;
                ProcessImage();
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                m_GridLines = !m_GridLines;
                gridToolStripMenuItem.Checked = m_GridLines;
                ProcessImage();
            }
        }

        private void picSprite_Click(object sender, EventArgs e)
        {

        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                m_Image.ToggleHighlight();
                picSprite.Image = m_Image.PostProcess;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sfdImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    m_Image.Image.Save(sfdImage.FileName);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Oh god this failed I'm so sorry, it could be that you are saving to a location this application isn't allowed to touch.\r\nLike Program Files or Outer Space. The technical reason is\r\n" + Ex.Message, "Oh no oh no oh no");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void beadSurgeSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.zed-ex.com");
        }

        private void viewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void flipHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                m_FlipHorizontal = !m_FlipHorizontal;
                flipHorizontalToolStripMenuItem.Checked = m_FlipHorizontal;
                ProcessImage();
            }
        }

        private void originalColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_OriginalImage != null)
            {
                m_OriginalColor = !m_OriginalColor;
                originalColorToolStripMenuItem.Checked = m_OriginalColor;
                ProcessImage();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Currently Running v1.1... YAY");
        }
    }
}
