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
    public partial class BeadSupply : UserControl
    {
        public event EventHandler BeadChange;
        Colour m_Colour;

        public Colour Colour
        {
            get { return m_Colour; }
            set { m_Colour = value; }
        }

        public BeadSupply()
        {
            InitializeComponent();
        }

        public BeadSupply(Colour colour)
        {
            InitializeComponent();
            m_Colour = colour;
            plcColour.SetColor(colour.Name);
            AssignValues();
        }

        private void AssignValues()
        {
            lblOwned.Text = m_Colour.Owned.ToString();
            lblUsed.Text = m_Colour.Used.ToString();
            lblSupply.Text = (m_Colour.Owned - m_Colour.Used).ToString();
            chkUse.Checked = m_Colour.Enabled;
        }

        private void BeadSupply_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                m_Colour.Owned += (int)nudAdd.Value;
                nudAdd.Value = 0;
                if (BeadChange != null)
                {
                    BeadChange(sender, new EventArgs());
                }
                AssignValues();
            }
        }

        private void nudAdd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            m_Colour.Enabled = chkUse.Checked;
            if (BeadChange != null)
            {
                BeadChange(sender, new EventArgs());
            }
            AssignValues();
        }

        public void SetColourEligibility(bool ok)
        {
            chkUse.Checked = ok;
        }
    }
}
