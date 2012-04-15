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
    public partial class Import : Form
    {
        public event EventHandler ImagePicked;
        Bitmap m_Input;
        Bitmap m_Output;

        public Bitmap Output
        {
            get { return m_Output; }
        }
        public Color BackgroundColor
        {
            get { return m_Input.GetPixel(0, 0); }
        }
        public Import()
        {
            InitializeComponent();
        }

        public Import(Bitmap input)
        {
            m_Input = input;
            
            InitializeComponent();
            picIn.Image = m_Input;
        }

        private void picIn_Click(object sender, EventArgs e)
        {

        }

        private void picIn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (m_Input.GetPixel(e.X, e.Y) != m_Input.GetPixel(0, 0) && ImagePicked != null)
                {
                    m_Output = hazardBitmap.FillSelect(m_Input, new Point(e.X,e.Y));
                    if (m_Output != null && m_Output.Width > 0 && m_Output.Height > 0)
                    {

                        ImagePicked(this, new EventArgs());
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
