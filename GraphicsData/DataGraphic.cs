using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GraphicsData
{
    class DataGraphic
    {
        private Data data;
        private PictureBox graphPB;
        private int inXMin;
        private int inXMax;
        private int outXMin;
        private int outXMax;
        private int inYMin;
        private int inYMax;
        private int outYMin;
        private int outYMax;

        static Bitmap graphBmp;// = new Bitmap();


        private int ScaleX(int inX, int inMin, int inMax, int outMin, int outMax)
        {
            int newX = (int)((float)(inX - inMin) / (float)(inMax - inMin) * (float)(outMax - outMin) * 0.95);
            return (newX);
        }

        private int ScaleY(int inX, int inMin, int inMax, int outMin, int outMax)
        {
            int newX = (int)((float)(inMax - inX) / (float)(inMax - inMin) * (float)(outMax - outMin) * 0.95);
            return (newX);
        }
        public DataGraphic(Data dataIn, PictureBox pb, int from)
        {
            if ((dataIn != null) && (dataIn.X.Count != 0))
            {
                data = dataIn;
                graphPB = pb;
                graphBmp = new Bitmap(graphPB.Width, graphPB.Height);
                graphPB.Image = graphBmp;

                inXMin = from;
                inXMax = from + 100;//Math.Min(data.X[data.X.Count - 1], 100);
                outXMin = 0;
                outXMax = graphPB.Size.Width;
                inYMin = 0;
                inYMax = data.Y[data.MaxInd];
                outYMin = 0;
                outYMax = graphPB.Size.Height;
            }
            else
            {
                MessageBox.Show("Please select file with data");
                throw new Exception("Data file was not selected");
            }
        }

        public void Draw(int from, int to)
        {
            Graphics g = Graphics.FromImage(graphBmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, 0, 0, graphBmp.Width, graphBmp.Height);
            Point p1 = new Point(0, 0);
            Point p2;
            for(int i = from; (i < data.X.Count) && (i < to); i ++)
            {
                p2 = new Point(ScaleX(data.X[i], inXMin, inXMax, outXMin, outXMax), ScaleY(data.Y[i], inYMin, inYMax, outYMin, outYMax));

                if(i > from)
                    g.DrawLine(new Pen(Color.Red, 2), p1.X, p1.Y, p2.X, p2.Y);

                Font drawFont = new Font("Arial", 7);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                g.DrawString(String.Format("P{0} ({1}, {2})", i.ToString(), data.X[i], data.Y[i]), drawFont, drawBrush, p2);
                p1 = p2;
            }
        }
    }
}
