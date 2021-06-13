using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gametest1
{
    class Charactor
    {
        int Width;

        public Charactor()
        {

        }

        public void Draw(object sender, PaintEventArgs e, Point p)
        {
            Image newImage = Image.FromFile(@"C:\Users\kanon\source\testC#\Gametest1\Gametest1\picture\pollman2.png");
            e.Graphics.DrawImage(newImage, p);
            Width = newImage.Width;
        }

        public int w()
        {
            int haba = Width;
            return haba;
        }

    }
}
