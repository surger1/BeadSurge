using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace BeadSurge
{
    public partial class PalletColorCombo : UserControl
    {
        public event EventHandler ColorChange;
        private Dictionary<string,Colour> m_Colors;

        public PalletColorCombo()
        {
            InitializeComponent();
            LoadColorPossibilities();
            cmbColor.DrawMode = DrawMode.OwnerDrawFixed;
        }

        public Colour GetSelectedColour()
        {
            return m_Colors[cmbColor.SelectedItem.ToString()];
        }

        public Colour GetColour(string s)
        {
            return m_Colors[s];
        }

        private void LoadColorPossibilities()
        {
            m_Colors = new Dictionary<string, Colour>();

            XmlDocument ColDoc = new XmlDocument();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BeadSurge\\Colours.xml");
            ColDoc.Load(path);

            XmlNodeList ColorNodes = ColDoc.SelectNodes("//Color");

            foreach (XmlNode col in ColorNodes)
            {
                int red = Convert.ToInt32(col.Attributes["red"].Value);
                int green = Convert.ToInt32(col.Attributes["green"].Value);
                int blue = Convert.ToInt32(col.Attributes["blue"].Value);
                int owned = Convert.ToInt32(col.Attributes["owned"].Value);
                int used = Convert.ToInt32(col.Attributes["used"].Value);
                bool enabled = Convert.ToBoolean(col.Attributes["enabled"].Value);
                string type = col.Attributes["type"].Value;
                string name = col.Attributes["name"].Value;

                m_Colors.Add(name + " - " + type,new Colour(name, Color.FromArgb(red, green, blue), owned, used, enabled,type));

                cmbColor.Items.Add(name + " - " + type);
            }
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.BackColor = m_Colors[cmbColor.SelectedItem.ToString()].Color;
            if (ColorChange != null)
            {
                ColorChange(sender, e);
            }
            
        }

        private void cmbColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            // Draw the background 


            SolidBrush myBrush = new SolidBrush(Color.Black);
            if(m_Colors[text].Color.GetBrightness() < 100f)
            {
                myBrush = new SolidBrush(Color.White);
            }
            SolidBrush myPen = new SolidBrush(m_Colors[text].Color);

            e.Graphics.FillRectangle(myPen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height); 

            // Get the item text    
            

            // Determine the forecolor based on whether or not the item is selected    
            


            // Draw the text    
            e.Graphics.DrawString(text, ((Control)sender).Font, myBrush, e.Bounds.X, e.Bounds.Y);


        }

        public void SetColor(string col)
        {
            for (int i = 0; i < cmbColor.Items.Count; ++i)
            {
                if (cmbColor.Items[i].ToString() == col)
                {
                    cmbColor.SelectedIndex = i;
                }
            }
        }

        private void PalletColorCombo_Load(object sender, EventArgs e)
        {

        }
    }
}
