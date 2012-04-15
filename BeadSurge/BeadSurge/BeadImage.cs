using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BeadSurge
{
    class BeadImage
    {
        Bitmap m_Image;
        Bitmap m_Highlight;
        bool m_Highlighted;
        Color m_IgnoreColor;
        bool m_FlipHorizontal;

        public bool Highlighted
        {
            get { return m_Highlighted; }
            set { m_Highlighted = value; }
        }
        bool m_Isolated;
        bool m_GridLines = true;
        Color? m_Flash;

        public Color? Flash
        {
            get { return m_Flash; }
            set { m_Flash = value; }
        }

        public bool GridLines
        {
            set { m_GridLines = value; }
        }
        bool m_Pegs = true;

        public void TogglePegs()
        {
            m_Pegs = !m_Pegs;
        }

        public void ToggleHighlight()
        {
            m_Highlighted = !m_Highlighted;
        }

        public void ToggleGridlines()
        {
            m_GridLines = !m_GridLines;
        }

        public Bitmap Image
        {
            get { return m_Image; }
            set { m_Image = value; }
        }
        Bitmap m_PostProcess;

        public Bitmap PostProcess
        {
            get
            {
                if (m_Highlighted)
                {
                    return m_Highlight;
                }
                else
                {
                    return m_PostProcess;
                }

            }
        }

        int m_Zoom;

        public int Zoom
        {
            get { return m_Zoom; }
            set { m_Zoom = value;
            m_PostProcess = Reprocesses();
            }
        }
        bool m_Bead;

        public bool Bead
        {
            get { return m_Bead; }
            set { m_Bead = value;
            m_PostProcess = Reprocesses();
            }
        }

        public BeadImage(Bitmap image,int zoom,bool bead,bool pegs,bool grid,Color? flash, Color ignore,bool flipHorizontal )
        {
            m_Image = image;
            m_Zoom = zoom;
            m_Bead = bead;
            m_Pegs = pegs;
            m_Flash = flash;
            m_GridLines = grid;
            m_FlipHorizontal = flipHorizontal;

            m_PostProcess = Reprocesses();
            m_Isolated = false;
            m_IgnoreColor = ignore;
        }

        public Bitmap Reprocesses()
        {
            Color temp = Color.Transparent;
                if (m_Flash != null)
                {
                   temp = (Color)m_Flash;
                }
            if (m_FlipHorizontal)
            {
                m_Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            m_Highlight = hazardBitmap.Reprocess(m_Image, new Bitmap(m_Image.Width * m_Zoom, m_Image.Height * m_Zoom), m_Zoom, m_GridLines, m_Pegs, temp.ToArgb(),m_IgnoreColor);
            m_PostProcess = hazardBitmap.Reprocess(m_Image, new Bitmap(m_Image.Width * m_Zoom, m_Image.Height * m_Zoom), m_Zoom, m_GridLines, m_Pegs, Color.Transparent.ToArgb(), m_IgnoreColor);
            if (m_FlipHorizontal)
            {
                m_Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            
            return m_PostProcess;
        }

        public Bitmap Isolate(int x, int y)
        {
            if(!m_Isolated)
            {
                m_PostProcess = hazardBitmap.Isolate(m_Image, new Bitmap(m_Image.Width * m_Zoom, m_Image.Height * m_Zoom), m_Zoom, x, y, m_IgnoreColor);
                m_Isolated = true;
            }
            else
            {
                Color temp = Color.Transparent;
                if (m_Flash != null)
                {
                   temp = (Color)m_Flash;
                }

                m_PostProcess = hazardBitmap.Reprocess(m_Image, new Bitmap(m_Image.Width * m_Zoom, m_Image.Height * m_Zoom), m_Zoom, m_GridLines, m_Pegs, temp.ToArgb(), m_IgnoreColor);
                m_Isolated = false;
            }
            if (m_FlipHorizontal)
            {
                m_PostProcess.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            return m_PostProcess;
        }

        public Color MouseColor(int x, int y)
        {
            try
            {
                
                return hazardBitmap.PointColor(m_Image, x, y, m_Zoom);
            }
            catch (Exception ex)
            {
                return Color.Lime;
            }
        }

    }
}
