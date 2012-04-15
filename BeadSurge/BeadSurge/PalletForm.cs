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
    public partial class PalletForm : Form
    {
        public event EventHandler ColorChange;
        Pallet m_Pallet;
        List<ImageColor> colors = new List<ImageColor>();
        public PalletForm(Pallet pallet)
        {
            InitializeComponent();
            m_Pallet = pallet;
            LoadPallet();
        }

        private void LoadPallet()
        {
            for (int i = 0; i < m_Pallet.FoundMatches.Count; ++i)
            {
                ImageColor col = new ImageColor(m_Pallet.FoundMatches.Values.ElementAt(i), m_Pallet.FoundMatches.Keys.ElementAt(i));
                col.Location = new System.Drawing.Point(12, 24 + (24 * i));
                col.Name = "imageColor" + i.ToString();
                col.Size = new System.Drawing.Size(1108, 33);
                col.TabIndex = 0;
                col.ColorChange += imageColor1_ColorChange;
                colors.Add(col);
                panel1.Controls.Add(col);
            }
        }

        

        private void imageColor1_ColorChange(object sender, EventArgs e)
        {
            

            for (int i = 0; i < colors.Count; ++i)
            {
                m_Pallet.FoundMatches.Values.ElementAt(i).AbsorbMatch(colors[i].GetMatch());
                m_Pallet.FoundInts[colors[i].MainColorInt()] = colors[i].GetMatch().BestMatch.Color.ToArgb();
                
            }

            if (ColorChange != null)
            {
                ColorChange(sender, e);
            }
        }

        private void PalletForm_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
