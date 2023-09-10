using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.
using DLLform;

namespace DLLform
{
    public partial class clock : UserControl
    {

        private BufferedGraphicsContext CurrentContext;
        private float radius;
        private Point center;
        private Point center2;
        private DateTime dtime;
        private TimeSpan tspan;
        private int Esec;
        private int Emin;
      
        public clock()
        {
            
             
            InitializeComponent();
            if (Height > Width)
            {
                radius = Width / 2;
            }
            else
            {
                radius = Height / 2;
            }
            center = new Point(Width / 2, Height / 2);
            center2 = new Point(Width / 2, Height / 3);

        }

        public TimeSpan Totaltime
        {
            get
            {
                return tspan;
            }
        }


        public void Start()
        {
            int Esec = 0;
            int Emin = 0;
            timer1.Enabled = true;
            dtime = DateTime.Now;

        }

        public void Stop()
        {

            timer1.Enabled = false;
            tspan = DateTime.Now - dtime + tspan;


        }

        public void Stop2()
        {
            timer1.Enabled = false;
        }

        public void Pause()
        {

            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                tspan = DateTime.Now - dtime + tspan;

            }
        }

        public void Resume()
        {

            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                dtime = DateTime.Now;
                

            }

        }
       

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);

            bg.Render();
        }

        private void DrawLines(Graphics g)
        {
            Pen myPen1 = new Pen(Color.Cyan, radius * 0.07f);
            Pen myPen2 = new Pen(Color.Black, radius * 0.05f);
            Pen myPen3 = new Pen(Color.Black, radius * 0.02f);

            for (int i = 0; i < 4; i++)
            {
                float x = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .7f + center.X;
                float y = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .7f + center.Y;

                float x2 = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .8f + center.X;
                float y2 = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .8f + center.Y;

                g.DrawLine(myPen1, x, y, x2, y2);
            }

            
            for (int i = 0; i < 4; i++)
            {
                float x = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .2f + center2.X;
                float y = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .2f + center2.Y;

                float x2 = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .3f + center2.X;
                float y2 = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .3f + center2.Y;

                g.DrawLine(myPen1, x, y, x2, y2);
            }

            for (int i = 0; i < 12; i++)
            {

                if (i % 3 != 0)
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .7f + center.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .7f + center.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .8f + center.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .8f + center.Y;

                    g.DrawLine(myPen2, x, y, x2, y2);
                }
            }

            for (int i = 0; i < 12; i++)
            {

                if (i % 3 != 0)
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .2f + center2.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .2f + center2.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .3f + center2.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .3f + center2.Y;

                    g.DrawLine(myPen2, x, y, x2, y2);
                }
            }



            for (int i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                {
                    float x = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .7f + center.X;
                    float y = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .7f + center.Y;

                    float x2 = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .8f + center.X;
                    float y2 = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .8f + center.Y;

                    g.DrawLine(myPen3, x, y, x2, y2);
                }
            }

            

            for (int i = 1; i < 12; i++)
            {
                if (i % 5 == 0)
                {
                    float x = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .2f + center2.X;
                    float y = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .2f + center2.Y;

                    float x2 = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .3f + center2.X;
                    float y2 = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .3f + center2.Y;

                    g.DrawLine(myPen3, x, y, x2, y2);
                }
            }

            


        }

    

        private void DrawNumbers(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Font numfont = new Font("Tahoma", radius * 0.11f, FontStyle.Bold);
            Brush numberBrush = new SolidBrush(Color.Black);

            for (int i = 0; i <= 55; i++)
            {
                if (i % 5 == 0)
                { 

                     float x = (float)Math.Cos((i  * 6 - 90) * Math.PI / 180) * radius * .9f + center.X;
                     float y = (float)Math.Sin((i * 6 - 90) * Math.PI / 180) * radius * .9f + center.Y;
                     g.DrawString(i.ToString(), numfont, numberBrush, x, y, sf);

                }
            }

        }

        private void DrawHands(Graphics g)
        {
           // Pen hourPen = new Pen(Color.Red, radius * 0.05f);
            Pen minutePen = new Pen(Color.Blue, radius * 0.03f);
            Pen secondPen = new Pen(Color.DeepPink, radius * 0.01f);

           // DateTime now = DateTime.Now;

            //Make use of this in your stopwatch!!
            TimeSpan x = DateTime.Now - dtime;
            

           // int hours = x.Hours;
            int minutes = x.Minutes;
            int seconds = x.Seconds;


           // float hx = (float)Math.Cos((hours * 30 - 90) * Math.PI / 180) * radius * .5f + center.X;
            //float hy = (float)Math.Sin((hours * 30 - 90) * Math.PI / 180) * radius * .5f + center.Y;

            float mx = (float)Math.Cos((minutes * 6 - 90) * Math.PI / 180) * radius * .7f + center.X;
            float my = (float)Math.Sin((minutes * 6 - 90) * Math.PI / 180) * radius * .7f + center.Y;


            float sx = (float)Math.Cos((seconds * 6 - 90) * Math.PI / 180) * radius * .75f + center.X;
            float sy = (float)Math.Sin((seconds * 6 - 90) * Math.PI / 180) * radius * .75f + center.Y;

           // g.DrawLine(hourPen, center.X, center.Y, hx, hy);
            g.DrawLine(minutePen, center.X, center.Y, mx, my);
            g.DrawLine(secondPen, center.X, center.Y, sx, sy);




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);

            bg.Render();
        }

        private void Clock_Resize(object sender, EventArgs e)
        {
            double tempheight = Height/2;
            if (Height > Width)
            {
                radius = Width / 2;
            }
            else
            {
                radius = Height / 2;
            }
            center = new Point(Width / 2, Height / 2);
            center2 = new Point(Width / 2, ((int)((int)(tempheight * -0.2) + tempheight)));

            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);

            bg.Render();



        }



       

        

    }

}

