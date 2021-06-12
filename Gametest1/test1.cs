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

            if(ball.X >= 0)
            {
                a = 300;
            }
            else
            {
                a = 300;
            }


            return a;
        }

        public void Draw(object sender, PaintEventArgs e)
            {
            Form1 F = new Form1();
            
            Pen blackPen = new Pen(Color.Black, 3);
            
            e.Graphics.DrawLine(blackPen, 0, 300, F.Bounds.Width, 300);
        }
        
    }
}
