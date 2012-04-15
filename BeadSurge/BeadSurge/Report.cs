using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BeadSurge
{
    public partial class Report : Form
    {
        Bitmap m_Image;
        Dictionary<Colour, int> m_Colours;
        Dictionary<Color, Colour> m_ColorToColour;
        Pallet m_Pallet;
        List<PalletColorCombo> colors;
        int tot;
        string m_Report = "";

        public Report()
        {
            InitializeComponent();
        }
        public Report(Bitmap image, Pallet pallet)
        {
            InitializeComponent();
            m_Image = image;
            m_Pallet = pallet;
            LoadNumbers();
        }

       
        
        public void LoadNumbers()
        {
            string RepHead = "";
            string RepCol = "";
            tot = 0;
            colors = new List<PalletColorCombo>();
            m_Colours = new Dictionary<Colour,int>();
            m_ColorToColour = new Dictionary<Color, Colour>();
            for (int i = 0; i < m_Pallet.FoundMatches.Keys.Count; ++i)
            {
                if (!m_Colours.ContainsKey(m_Pallet.FoundMatches.Values.ElementAt(i).BestMatch))
                {
                    m_Colours.Add(m_Pallet.FoundMatches.Values.ElementAt(i).BestMatch,0);
                    if (!m_ColorToColour.ContainsKey(m_Pallet.FoundMatches.Values.ElementAt(i).BestMatch.Color))
                    {
                        m_ColorToColour.Add(m_Pallet.FoundMatches.Values.ElementAt(i).BestMatch.Color, m_Pallet.FoundMatches.Values.ElementAt(i).BestMatch);
                    }
                }
            }
            Color ignore = m_Image.GetPixel(0, 0);
            for (int x = 0; x < m_Image.Width; ++x)
            {
                for (int y = 0; y < m_Image.Height; ++y)
                {
                    Color col = m_Image.GetPixel(x,y);
                    if(col != ignore)
                    {
                        m_Colours[m_ColorToColour[col]]++;
                    }
                    
                }
            }

            for (int i = 0; i < m_Colours.Keys.Count; ++i)
            {
                PalletColorCombo col = new PalletColorCombo();
                col.Location = new System.Drawing.Point(12, 98 + (24 * i));
                col.Name = "imageColor" + i.ToString();
                col.TabIndex = 0;
                col.SetColor(m_Colours.Keys.ElementAt(i).Name);
                RepCol += m_Colours.Keys.ElementAt(i).Name + "\t\t\t";

                col.Enabled = false;
                colors.Add(col);
                panel1.Controls.Add(col);

                Label lbl = new Label();
                lbl.Location = new System.Drawing.Point(350, 106 + (24 * i));
                lbl.Name = "lblCol" + i.ToString();
                lbl.TabIndex = 0;
                lbl.Text = m_Colours.Values.ElementAt(i).ToString();
                RepCol += m_Colours.Values.ElementAt(i).ToString() + "\r\n";
                panel1.Controls.Add(lbl);

                tot += m_Colours.Values.ElementAt(i);
            }
            lblTotal.Text = tot.ToString();
            
            int grids = (int)(Math.Ceiling(((float)m_Image.Width / 29f)) * Math.Ceiling(((float)m_Image.Height / 29f)));
            lblGrids.Text = grids.ToString();
            string dec = ((float)tot * 0.00225f).ToString();
            //dec = dec.Remove( dec.LastIndexOf('.') + 2);
            lblCost.Text = "$" + dec;
            float min = (float)tot * 0.16666f;
            lblTime.Text = ((int)(min / 60.0f)).ToString() + "h " + ((int)(min % 60.0f)).ToString() + "m";
            lblPixels.Text = m_Image.Width.ToString() + " x " + m_Image.Height.ToString();
            lblInches.Text = ((float)m_Image.Width * 0.1968f).ToString() + "\" x " + ((float)m_Image.Height * 0.1968f).ToString() + "\"";
            lblcm.Text = ((float)m_Image.Width * 0.5).ToString() + "cm x " + ((float)m_Image.Height * 0.5).ToString() + "cm";
            RepHead = String.Format("Total Beads:\t\t\t{0}\r\nTotal Grids:\t\t\t{1}\r\nEstimatedTime:\t\t\t{2}\r\nEstimated Cost:\t\t\t{3}\r\n\r\n",lblTotal.Text,lblGrids.Text,lblTime.Text,lblCost.Text);
            m_Report = RepHead + RepCol;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Millisecond.ToString()+"Report.txt");
            tw.Write(m_Report);
            tw.Close();
        }
    }
}
