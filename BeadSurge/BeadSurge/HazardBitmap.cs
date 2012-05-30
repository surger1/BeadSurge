using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;


namespace BeadSurge
{
    public class HSL
    {
        public HSL()
        {
            _h = 0;
            _s = 0;
            _l = 0;
        }

        double _h;
        double _s;
        double _l;

        public double H
        {
            get { return _h; }
            set
            {
                _h = value;
                _h = _h > 1 ? 1 : _h < 0 ? 0 : _h;
            }
        }

        public double S
        {
            get { return _s; }
            set
            {
                _s = value;
                _s = _s > 1 ? 1 : _s < 0 ? 0 : _s;
            }
        }

        public double L
        {
            get { return _l; }
            set
            {
                _l = value;
                _l = _l > 1 ? 1 : _l < 0 ? 0 : _l;
            }
        }
    }

    public unsafe struct hazardBitmap
    {
        public static Color HSL_to_RGB(HSL hsl)
        {
            double r = 0, g = 0, b = 0;
            double temp1, temp2;

            if (hsl.L == 0)
            {
                r = g = b = 0;
            }
            else
            {
                if (hsl.S == 0)
                {
                    r = g = b = hsl.L;
                }
                else
                {
                    temp2 = ((hsl.L <= 0.5) ? hsl.L * (1.0 + hsl.S) : hsl.L + hsl.S - (hsl.L * hsl.S));
                    temp1 = 2.0 * hsl.L - temp2;

                    double[] t3 = new double[] { hsl.H + 1.0 / 3.0, hsl.H, hsl.H - 1.0 / 3.0 };
                    double[] clr = new double[] { 0, 0, 0 };
                    for (int i = 0; i < 3; i++)
                    {
                        if (t3[i] < 0)
                            t3[i] += 1.0;
                        if (t3[i] > 1)
                            t3[i] -= 1.0;

                        if (6.0 * t3[i] < 1.0)
                            clr[i] = temp1 + (temp2 - temp1) * t3[i] * 6.0;
                        else if (2.0 * t3[i] < 1.0)
                            clr[i] = temp2;
                        else if (3.0 * t3[i] < 2.0)
                            clr[i] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
                        else
                            clr[i] = temp1;
                    }
                    r = clr[0];
                    g = clr[1];
                    b = clr[2];
                }
            }

            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
        }
        
        public static short LoWord(int n)
        {
            return (short)(n & 0xffff);
        }
        public static short HiWord(int n)
        {
            return (short)((n >> 16) & 0xffff);
        }
        public static byte LoByte(short n)
        {
            return (byte)(n & 0xff);
        }
        public static byte HiByte(short n)
        {
            return (byte)((n >> 8) & 0xff);
        }
        public static byte GetR(int ARGB)
        {
            return LoByte((byte)LoWord(ARGB));

        }
        public static byte GetG(int ARGB)
        {
            return HiByte((short)LoWord(ARGB));

        }
        public static byte GetB(int ARGB)
        {
            return LoByte((byte)HiWord(ARGB));

        }
        public static byte GetA(int ARGB)
        {
            return HiByte((byte)HiWord(ARGB));

        }
        public static int BGRA(byte B, byte G, byte R, byte A)
        {
            return (int)(B + (G << 8) + (R << 16) + (A << 24));
        }
        public static int CoordsToIndex(int x, int y, int stride)
        {
            return (stride * y) + (x * 4);
        }
        public static bool CheckPixel(byte* px, byte* startcolor)
        {
            bool ret = true;
            for (byte i = 0; i < 3; i++)
                ret &= (px[i] >= (startcolor[i] - 0)) && px[i] <= (startcolor[i] + 0);
            return ret;
        }
        public static bool CheckPixel(int px, int startcolor)
        {
            bool ret = false;
            if (px != startcolor)
            {
                ret = true;
            }
            return ret;
        }

        public static Bitmap Reprocess(Bitmap input, int zoom,bool GridLines,bool Pegs, int highlight, Color IgnoreColor)
        {
            BitmapData bmpDataIn = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int newWidth = (((input.Width - (input.Width % 29)) / 29) + 1) * 29;
            int newHeight = (((input.Height - (input.Height % 29)) / 29) + 1) * 29;
            Bitmap bitmap = new Bitmap(newWidth * zoom, newHeight * zoom);
            BitmapData bmpDataOut = bitmap.LockBits(new Rectangle(0, 0, newWidth, newHeight), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0In = bmpDataIn.Scan0;
            System.IntPtr Scan0Out = bmpDataOut.Scan0;

            byte* scan0In = (byte*)(void*)Scan0In;
            byte* scan0Out = (byte*)(void*)Scan0Out;

            int ignoreColor = IgnoreColor.ToArgb();// (int*)(scan0In + (CoordsToIndex(0, 0, bmpDataIn.Stride)));

            int lime = Color.Lime.ToArgb(); ;

            int LightGray = Color.LightGray.ToArgb();
            int LightSlate = Color.LightSlateGray.ToArgb();
            int Black = Color.Black.ToArgb();
            int White = Color.White.ToArgb();
            int DarkGray = Color.DarkGray.ToArgb();
            int Red = Color.Red.ToArgb();
            int DarkRed = Color.DarkRed.ToArgb();

            for (int x = 0; x < newWidth; ++x)
            {
                for (int y = 0; y < newHeight; ++y)
                {
                    int* pIn = (int*)(scan0In + (CoordsToIndex(0, 0, bmpDataIn.Stride))); ;
                    if (x >= input.Width || y >= input.Height)
                    {
                        pIn[0] = ignoreColor;
                    }
                    else
                    {
                        pIn = (int*)(scan0In + (CoordsToIndex(x, y, bmpDataIn.Stride)));
                    }
                    
                    for (int xx = 0; xx < zoom; ++xx)
                    {
                        for (int yy = 0; yy < zoom; ++yy)
                        {
                            int* pOut;
                            

                            pOut = (int*)(scan0Out + (CoordsToIndex((x * zoom) + xx, (y * zoom) + yy, bmpDataOut.Stride)));
                            
                            
                            if (pIn[0] == ignoreColor)
                            {
                                int Bad = LightGray;
                                

                                if ((((y - (y % 29)) / 29) + ((x - (x % 29)) / 29)) % 2 == 0)
                                {
                                    Bad = LightSlate;
                                }
                                if ((x + y) % 2 == 0)
                                {
                                    Bad = LightGray;
                                    if ((((y - (y % 29)) / 29) + ((x - (x % 29)) / 29)) % 2 == 0)
                                    {
                                        Bad = LightSlate;
                                    }
                                }

                                if (xx > (float)zoom * 0.25f && xx < (float)zoom * 0.75f && yy > (float)zoom * 0.25f && yy < (float)zoom * 0.75f && Pegs)
                                {

                                        Bad = DarkGray;
                                    

                                }

                                pOut[0] = Bad;

                            }
                            else
                            {
                                if (((xx + 1) % zoom == 0 || (yy + 1) % zoom == 0) && GridLines)
                                {

                                        int Bad = Black;
                                        if ((x % 29 == 28 && xx == zoom - 1) || (y % 29 == 28 && yy == zoom - 1))
                                        {
                                            Bad = DarkRed;
                                        }
                                        else
                                        {
                                            Bad = Black;
                                        }

                                        if ((xx + yy) % 2 == 0)
                                        {
                                            if ((x % 29 == 28 && xx == zoom - 1) || (y % 29 == 28 && yy == zoom - 1))
                                            {
                                                Bad = Red;
                                            }
                                            else
                                            {
                                                Bad = White;
                                            }

                                        }
                                    

                                    pOut[0] = Bad;
                                }
                                else
                                {
                                    if (pIn[0] == highlight)
                                    {
                                        pOut[0] = lime;
                                    }
                                    else
                                    {
                                        pOut[0] = pIn[0];
                                    }
                                }
                            }
                        }
                    }
                }
            }
            input.UnlockBits(bmpDataIn);
            bitmap.UnlockBits(bmpDataOut);
            return bitmap;
        }

        public static Bitmap Isolate(Bitmap input, Bitmap bitmap, int zoom,int mx, int my,Color IgnoreColor)
        {
            BitmapData bmpDataIn = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData bmpDataOut = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0In = bmpDataIn.Scan0;
            System.IntPtr Scan0Out = bmpDataOut.Scan0;

            byte* scan0In = (byte*)(void*)Scan0In;
            byte* scan0Out = (byte*)(void*)Scan0Out;

            int ignoreColor = IgnoreColor.ToArgb(); //(int*)(scan0In + (CoordsToIndex(0, 0, bmpDataIn.Stride)));

            int modx = (mx - (mx % zoom)) / zoom;
            int mody = (my - (my % zoom)) / zoom;

            int* isolateColor = (int*)(scan0In + (CoordsToIndex(modx, mody, bmpDataIn.Stride)));

            int LightGray = Color.LightGray.ToArgb();
            int LightSlate = Color.LightSlateGray.ToArgb();
            int Black = Color.Black.ToArgb();
            int White = Color.White.ToArgb();

            for (int x = 0; x < input.Width; ++x)
            {
                for (int y = 0; y < input.Height; ++y)
                {
                    int* pIn = (int*)(scan0In + (CoordsToIndex(x, y, bmpDataIn.Stride)));

                    for (int xx = 0; xx < zoom; ++xx)
                    {
                        for (int yy = 0; yy < zoom; ++yy)
                        {
                            int* pOut = (int*)(scan0Out + (CoordsToIndex((x * zoom) + xx, (y * zoom) + yy, bmpDataOut.Stride)));
                            if (pIn[0] == ignoreColor || pIn[0] != isolateColor[0])
                            {
                                int Bad = LightGray;

                                if ((((y - (y % 29)) / 29) + ((x - (x % 29)) / 29)) % 2 == 0)
                                {
                                    Bad = LightSlate;
                                }
                                if ((x + y) % 2 == 0)
                                {
                                    Bad = LightGray;
                                    if ((((y - (y % 29)) / 29) + ((x - (x % 29)) / 29)) % 2 == 0)
                                    {
                                        Bad = LightSlate;
                                    }
                                }

                                pOut[0] = Bad;

                            }
                            else
                            {
                                if ((xx + 1) % zoom == 0 || (yy + 1) % zoom == 0)
                                {

                                    int Bad = Black;

                                    if ((xx + yy) % 2 == 0)
                                    {
                                        Bad = White;

                                    }


                                    pOut[0] = Bad;
                                }
                                else
                                {
                                    pOut[0] = pIn[0];
                                }
                            }
                        }
                    }
                }
            }
            input.UnlockBits(bmpDataIn);
            bitmap.UnlockBits(bmpDataOut);
            return bitmap;
        }

        public static Color PointColor(Bitmap input,int x ,int  y, int zoom)
        {

            BitmapData bmpData = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            System.IntPtr Scan0 = bmpData.Scan0;

            byte* scan0 = (byte*)(void*)Scan0;

            int modx = (x - (x % zoom)) / zoom;
            int mody = (y - (y % zoom)) / zoom;

            int* ignoreColor = (int*)(scan0 + (CoordsToIndex(modx, mody, bmpData.Stride)));
            int ret = ignoreColor[0];
            input.UnlockBits(bmpData);
            return Color.FromArgb(ret);
        }

        public static Bitmap MorphToPallet(Bitmap bitmap, Dictionary<int, int> FoundMatches,Color IgnoreColor)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0 = bmpData.Scan0;
            byte* scan0 = (byte*)(void*)Scan0;



            int ignoreColor = IgnoreColor.ToArgb();//(int*)(scan0 + (CoordsToIndex(0, 0, bmpData.Stride)));

            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    int* p = (int*)(scan0 + (CoordsToIndex(x, y, bmpData.Stride)));
                    if (p[0] == ignoreColor)
                    {
                        p[0] = ignoreColor;
                    }
                    else if (FoundMatches.ContainsKey(p[0]))
                    {
                        p[0] = FoundMatches[p[0]];
                    }
                }
            }
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }

        public static Bitmap FillSelect(Bitmap input, Point start)
        {
            List<Point> PixelQue;

            Bitmap bitmap = new Bitmap(input);

            int color = bitmap.GetPixel(0, 0).ToArgb();

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0 = bmpData.Scan0;

            byte* scan0 = (byte*)(void*)Scan0;

            int loc = CoordsToIndex(start.X, start.Y, bmpData.Stride);

            bool[,] PixelsChecked = new bool[bmpData.Width + 1, bmpData.Height + 1];
            bool[,] PixelsQueud = new bool[bmpData.Width + 1, bmpData.Height + 1];
            PixelQue = new List<Point>();
            List<Point> PixelTransfer = new List<Point>();
            int xLow = int.MaxValue;
            int xHigh = 0;
            int yLow = int.MaxValue;
            int yHigh = 0;
            PixelsChecked[start.X, start.Y] = true;

            PixelQue.Add(start);

            while (PixelQue.Count > 0)
            {
                if (PixelQue[0].X > xHigh)
                {
                    xHigh = PixelQue[0].X;
                }
                if (PixelQue[0].X < xLow)
                {
                    xLow = PixelQue[0].X;
                }
                if (PixelQue[0].Y > yHigh)
                {
                    yHigh = PixelQue[0].Y;
                }
                if (PixelQue[0].Y < yLow)
                {
                    yLow = PixelQue[0].Y;
                }
                int* p = (int*)(scan0 + (CoordsToIndex(PixelQue[0].X, PixelQue[0].Y, bmpData.Stride)));
                //left
                if (PixelQue[0].X > 0)
                {
                    int* ptr = (int*)(scan0 + (CoordsToIndex(PixelQue[0].X - 1, PixelQue[0].Y, bmpData.Stride)));
                    if (PixelsChecked[PixelQue[0].X - 1, PixelQue[0].Y] == false)
                    {
                        PixelsChecked[PixelQue[0].X - 1, PixelQue[0].Y] = true;
                        if (CheckPixel(ptr[0], color))
                        {
                            PixelQue.Add(new Point(PixelQue[0].X - 1, PixelQue[0].Y));
                        }

                    }
                }
                //right
                if (PixelQue[0].X < bmpData.Width - 1)
                {
                    int* ptr = (int*)(scan0 + (CoordsToIndex(PixelQue[0].X + 1, PixelQue[0].Y, bmpData.Stride)));
                    if (PixelsChecked[PixelQue[0].X + 1, PixelQue[0].Y] == false)
                    {
                        PixelsChecked[PixelQue[0].X + 1, PixelQue[0].Y] = true;
                        if (CheckPixel(ptr[0], color))
                        {
                            PixelQue.Add(new Point(PixelQue[0].X + 1, PixelQue[0].Y));
                        }
                    }
                }
                //Up
                if (PixelQue[0].Y < bmpData.Height - 1)
                {
                    int* ptr = (int*)(scan0 + (CoordsToIndex(PixelQue[0].X, PixelQue[0].Y + 1, bmpData.Stride)));
                    if (PixelsChecked[PixelQue[0].X, PixelQue[0].Y + 1] == false)
                    {
                        PixelsChecked[PixelQue[0].X, PixelQue[0].Y + 1] = true;
                        if (CheckPixel(ptr[0], color))
                        {
                            PixelQue.Add(new Point(PixelQue[0].X, PixelQue[0].Y + 1));
                        }
                    }
                }
                //Down
                if (PixelQue[0].Y > 0)
                {
                    int* ptr = (int*)(scan0 + (CoordsToIndex(PixelQue[0].X, PixelQue[0].Y - 1, bmpData.Stride)));
                    if (PixelsChecked[PixelQue[0].X, PixelQue[0].Y - 1] == false)
                    {
                        PixelsChecked[PixelQue[0].X, PixelQue[0].Y - 1] = true;
                        if (CheckPixel(ptr[0], color))
                        {
                            PixelQue.Add(new Point(PixelQue[0].X, PixelQue[0].Y - 1));
                        }
                    }
                }
                p[0] = color;
                PixelTransfer.Add(PixelQue[0]);
                PixelQue.RemoveAt(0);
            }

            bitmap.UnlockBits(bmpData);

            BitmapData bmpDataIn = input.LockBits(new Rectangle(0, 0, input.Width, input.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0In = bmpDataIn.Scan0;
            byte* scan0In = (byte*)(void*)Scan0In;

            Bitmap output = new Bitmap(xHigh - xLow + 1,yHigh - yLow + 1);
            BitmapData bmpDataOut = output.LockBits(new Rectangle(0, 0, output.Width, output.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0Out = bmpDataOut.Scan0;
            byte* scan0Out = (byte*)(void*)Scan0Out;

            for (int x = 0; x < output.Width; ++x)
            {
                for (int y = 0; y < output.Width; ++y)
                {

                }
            }

                for (int i = 0; i < PixelTransfer.Count; ++i)
                {
                    int* ptrIn = (int*)(scan0In + (CoordsToIndex(PixelTransfer[i].X, PixelTransfer[i].Y, bmpDataIn.Stride)));
                    int* ptrOut = (int*)(scan0Out + (CoordsToIndex(PixelTransfer[i].X - xLow, PixelTransfer[i].Y - yLow, bmpDataOut.Stride)));

                    ptrOut[0] = ptrIn[0];
                }

            input.UnlockBits(bmpDataIn);
            output.UnlockBits(bmpDataOut);

           return output;
        }

        public static Bitmap replace(Bitmap bitmap, Color c, Color nc)
        {
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            System.IntPtr Scan0 = bmpData.Scan0;
            byte* scan0 = (byte*)(void*)Scan0;

            int start = c.ToArgb();
            int replaced = nc.ToArgb();

            for (int y = 0; y < bitmap.Height; ++y)
            {
                for (int x = 0; x < bitmap.Width; ++x)
                {
                    int* p = (int*)(scan0 + (CoordsToIndex(x, y, bmpData.Stride)));
                    if (p[0] == start)
                    {
                        p[0] = replaced;
                    }
                }
            }
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
    }
}
