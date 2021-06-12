using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace Gametest1
{
    class test1
    {


        public void Test1()
        {

        }

        public int Grand(Vector ball)
        {
            int a = 0;

            if(ball.Y <= 350)
            {
                if(ball.Y <= 230)
                {
                    if(ball.X >= 100 && ball.X <= 250)
                    {
                        a = 230;
                    }
                    else
                    {
                        a = 350;
                    }
                }
                else
                {
                    a = 350;
                }
            }
            else
            {
                a = 350;
            }


            return a;
        }

        public int Wall(Vector ball)
        {
            Form1 F = new Form1();

            int b = 0;

            if(ball.X == 0)
            {
                b = 0;
            }else if(ball.X + 10 == F.Bounds.Width)
            {
                b = F.Bounds.Width;
            }

            return b;
        }

        public void Draw(object sender, PaintEventArgs e)
            {
            Form1 F = new Form1();
            
            Pen blackPen = new Pen(Color.Black, 3);
            
            e.Graphics.DrawLine(blackPen, 0, 350, F.Bounds.Width, 350);
            e.Graphics.DrawLine(blackPen, 100, 230, 250, 230);
        }
        
    }
}
