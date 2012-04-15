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
    public partial class BeadManagement : Form
    {
        Pallet m_Pallet;
        List<BeadSupply> colors = new List<BeadSupply>();
        public BeadManagement()
        {
            InitializeComponent();
        }

        public BeadManagement(Pallet pallet)
        {
            m_Pallet = pallet;
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BeadChange(object sender, EventArgs e)
        {
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }

        private void BeadManagement_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                BeadSupply col = new BeadSupply(m_Pallet.Colours[i]);
                col.Location = new System.Drawing.Point(12, 24 + (24 * i));
                col.Name = "imageColor" + i.ToString();
                col.Size = new System.Drawing.Size(1108, 33);
                col.TabIndex = 0;
                col.BeadChange += BeadChange;
                colors.Add(col);
                panel1.Controls.Add(col);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; ++i)
            {
                colors[i].BeadChange -= BeadChange;
                colors[i].SetColourEligibility(true);
                colors[i].BeadChange += BeadChange;
            }
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; ++i)
            {
                colors[i].BeadChange -= BeadChange;
                colors[i].SetColourEligibility(false);
                colors[i].BeadChange += BeadChange;
            }
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }

        private void onHandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; ++i)
            {
                colors[i].BeadChange -= BeadChange;
                colors[i].SetColourEligibility(m_Pallet.Colours[i].Owned > m_Pallet.Colours[i].Used);
                colors[i].BeadChange += BeadChange;
            }
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }

        private void perlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; ++i)
            {
                colors[i].BeadChange -= BeadChange;
                colors[i].SetColourEligibility(m_Pallet.Colours[i].Type.ToLower() == "perler");
                colors[i].BeadChange += BeadChange;
            }
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }

        private void hamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; ++i)
            {
                colors[i].BeadChange -= BeadChange;
                colors[i].SetColourEligibility(m_Pallet.Colours[i].Type.ToLower() == "hama");
                colors[i].BeadChange += BeadChange;
            }
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }

        private void nabbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colors.Count; ++i)
            {
                colors[i].BeadChange -= BeadChange;
                colors[i].SetColourEligibility(m_Pallet.Colours[i].Type.ToLower() == "nabbi");
                colors[i].BeadChange += BeadChange;
            }
            for (int i = 0; i < m_Pallet.Colours.Count; ++i)
            {
                m_Pallet.Colours[i] = colors[i].Colour;
            }
            m_Pallet.Save();
        }
    }
}
