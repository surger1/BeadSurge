using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeadSurge
{
    public partial class ImageColor : UserControl
    {
        public event EventHandler ColorChange;
        public Color m_Color;
        public Match m_Match;
        public ImageColor()
        {

        }
        public ImageColor(Match match, Color col)
        {
            InitializeComponent();
            m_Match = match;
            m_Color = col;
            pnlColor.BackColor = col;
            MatchCombo();
        }

        public int MainColorInt()
        {
            return m_Color.ToArgb();
        }

        public Match GetMatch()
        {
            return m_Match;
        }

        private void MatchCombo()
        {
            plcBest.SetColor(m_Match.BestMatch.Name);
            plcSecond.SetColor(m_Match.SecondBest.Name);
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            m_Match.SwapMatches();
            MatchCombo();
        }

        private void plcBest_Load(object sender, EventArgs e)
        {

        }

        private void plcBest_ColorChange(object sender, EventArgs e)
        {
            m_Match.BestMatch = plcBest.GetSelectedColour();
            if (ColorChange != null)
            {

                ColorChange(sender, e);
            }

            
        }

        private void ImageColor_Load(object sender, EventArgs e)
        {

        }

        private void plcSecond_Load(object sender, EventArgs e)
        {

        }
    }
}
