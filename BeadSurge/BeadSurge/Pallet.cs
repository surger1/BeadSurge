using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.IO;

namespace BeadSurge
{
    public class Colour
    {
        string m_Name;
        string m_Type;

        public string Type
        {
            get { return m_Type; }
        }

        public string Name
        {
            get { return m_Name + " - " + m_Type; }
        }
        Color m_Color;

        public Color Color
        {
            get { return m_Color; }
        }
        int m_Owned;

        public int Owned
        {
            get { return m_Owned; }
            set { m_Owned = value; }
        }
        int m_Used;

        public int Used
        {
            get { return m_Used; }
            set { m_Used = value; }
        }

        bool m_Enabled;

        public bool Enabled
        {
            get { return m_Enabled; }
            set { m_Enabled = value; }
        }

        public Colour(string Name, Color col, int owned, int used, bool enabled, string type)
        {
            m_Name = Name;
            m_Color = col;
            m_Owned = owned;
            m_Used = used;
            m_Enabled = enabled;
            m_Type = type;
        }

        public int Difference(Color col)
        {
            double ret = 0;

            ret += Math.Sqrt( Square(col.R - m_Color.R));
            ret += Math.Sqrt(Square(col.G - m_Color.G));
            ret += Math.Sqrt(Square(col.B - m_Color.B));
            //ret += Math.Sqrt((int)(Square((int)col.GetHue() - (int)m_Color.GetHue())));
            //ret += Math.Sqrt((int)(Square((int)col.GetSaturation() - (int)m_Color.GetSaturation())));
            //ret += Math.Sqrt((int)(Square((int)col.GetBrightness() - (int)m_Color.GetBrightness())));

            return (int)Math.Round(ret);
        }

        private int Square(int x)
        {
            return (x * x) / 2;
        }
    }

    public class Match
    {
        public Colour BestMatch;
        public int BestDif;
        public Colour SecondBest;
        public int SecondDif;
        

        public Match()
        {
        }

        public void NewMatch(Colour match, int dif)
        {
            SecondBest = BestMatch;
            SecondDif = BestDif;
            BestMatch = match;
            BestDif = dif;
        }

        public void SwapMatches()
        {
            Colour b = BestMatch;
            int dif = BestDif;

            BestMatch = null;
            BestDif = int.MaxValue;

            BestMatch = SecondBest;
            BestDif = SecondDif;

            SecondBest = b;
            SecondDif = dif;

        }

        public void AbsorbMatch(Match other)
        {
            SecondBest = other.SecondBest;
            SecondDif = other.SecondDif;
            BestMatch = other.BestMatch;
            BestDif = other.BestDif;
        }
    }

    public class Pallet
    {
        public List<Colour> Colours = new List<Colour>();
        public bool HighContrast = false;
        Dictionary<Color, Match> m_FoundMatches = new Dictionary<Color, Match>();
        Dictionary<int, int> m_FoundInts = new Dictionary<int, int>();

        public Dictionary<int, int> FoundInts
        {
            get { return m_FoundInts; }
        }

        public Dictionary<Color, Match> FoundMatches
        {
            get { return m_FoundMatches; }
        }

        public Pallet()
        {
            LoadPallet();
        }

        public void UpdateColour(Colour col, int number)
        {
            for (int i = 0; i < Colours.Count; ++i)
            {
                if (col.Name == Colours[i].Name)
                {
                    Colours[i].Used += number;
                }
            }
        }

        public Colour ColorToColour(Color col)
        {
            for (int i = 0; i < Colours.Count; ++i)
            {
                if (Colours[i].Color == col)
                {
                    return Colours[i];
                }
            }
            return null;
        }

        private void LoadPallet()
        {
            Colours = new List<Colour>();
            XmlDocument ColDoc = new XmlDocument();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BeadSurge\\Colours.xml");
            ColDoc.Load(path);

            XmlNodeList ColorNodes = ColDoc.SelectNodes("//Color");

            foreach(XmlNode col in ColorNodes)
            {
                int red = Convert.ToInt32(col.Attributes["red"].Value);
                int green = Convert.ToInt32(col.Attributes["green"].Value);
                int blue = Convert.ToInt32(col.Attributes["blue"].Value);
                int owned = Convert.ToInt32(col.Attributes["owned"].Value);
                int used = Convert.ToInt32(col.Attributes["used"].Value);
                bool enabled = Convert.ToBoolean(col.Attributes["enabled"].Value);
                string type = col.Attributes["type"].Value;

                string name = col.Attributes["name"].Value;

                Colours.Add(new Colour(name, Color.FromArgb(red, green, blue), owned, used, enabled,type));
            }
            
        }

        public void Save()
        {
            if (Colours.Count > 0)
            {
                XmlDocument ColDoc = new XmlDocument();
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BeadSurge\\Colours.xml");
                ColDoc.Load(path);

                XmlNodeList ColorNodes = ColDoc.SelectNodes("//Color");
                int i = 0;
                foreach (XmlNode col in ColorNodes)
                {

                    col.Attributes["owned"].Value = Colours[i].Owned.ToString();
                    col.Attributes["used"].Value = Colours[i].Used.ToString();
                    col.Attributes["enabled"].Value = Colours[i].Enabled.ToString();


                    i++;
                }
                //XmlWriter writer = XmlWriter.Create("..\\..\\Colours.xml");
               // writer.Settings.Indent = true;

                ColDoc.Save(path);
            }
        }

        public void ImportPallet(Bitmap input)
        {
            m_FoundMatches = new Dictionary<Color, Match>();
            m_FoundInts = new Dictionary<int, int>();
            Color ignoreColor = input.GetPixel(0, 0);
            for (int x = 0; x < input.Width; ++x)
            {
                for (int y = 0; y < input.Height; ++y)
                {
                    Color sel = input.GetPixel(x, y);
                    if (sel != ignoreColor && !m_FoundMatches.Keys.Contains(sel))
                    {
                        Match match = FindMatch(sel);
                        m_FoundMatches.Add(sel, match);
                        m_FoundInts.Add(sel.ToArgb(), match.BestMatch.Color.ToArgb());
                    }
                }
            }

            if (HighContrast)
            {
                ImprovePallet(m_FoundMatches);
            }
        }

        public Bitmap MorphToPallet(Bitmap input,Color ignore,bool Original)
        {
            Bitmap Output = new Bitmap(input);

            if (!Original)
            {
                Output = hazardBitmap.MorphToPallet(Output, m_FoundInts, ignore);
            }
            return Output;
        }

        public void ImprovePallet(Dictionary<Color, Match> FoundMatches)
        {
            for(int i = 0; i < FoundMatches.Keys.Count;++i)
            {
                UpdateColor(FoundMatches.Values.ElementAt(i).BestMatch, FoundMatches);
            }
        }

        public void UpdateColor(Colour col, Dictionary<Color, Match> FoundMatches)
        {
            Color BestMatch = col.Color;
            Match BestColour = new Match();
            int lowest = int.MaxValue;
            for(int i = 0; i < FoundMatches.Keys.Count;++i)
            {
                if (FoundMatches.Values.ElementAt(i).BestMatch == col)
                {
                    if (FoundMatches.Values.ElementAt(i).BestDif < lowest)
                    {
                        BestMatch = FoundMatches.Keys.ElementAt(i);
                        BestColour = FoundMatches.Values.ElementAt(i);
                        lowest = FoundMatches.Values.ElementAt(i).BestDif;
                    }
                }
            }

            for (int i = 0; i < FoundMatches.Keys.Count; ++i)
            {
                if (FoundMatches.Values.ElementAt(i).BestMatch== col)
                {
                    if (FoundMatches.Keys.ElementAt(i) != BestMatch && FoundMatches.Values.ElementAt(i).SecondDif < BestColour.SecondDif)
                    {
                        FoundMatches.Values.ElementAt(i).SwapMatches();
                    }
                }
            }
        }
      
        public Match FindMatch (Color col)
        {
            Match CurrentWinner = new Match();
            CurrentWinner.NewMatch(new Colour("",Color.Black,0,0,true,""),int.MaxValue);
            for (int i = 0; i < Colours.Count; ++i)
            {
                int dif = Colours[i].Difference(col);
                if (dif < CurrentWinner.BestDif && Colours[i].Enabled)
                {
                    CurrentWinner.NewMatch(Colours[i], dif);
                }
            }
            return CurrentWinner;
        }
    }
}
