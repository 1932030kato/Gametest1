using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Gametest1
{
    public partial class Form1 : Form
    {
        Vector ballPos;
        Vector ballSpeed;
        int ballRadius;
        int gravity = 1;
        int sw = 0;
        test1 t = new test1();
        Timer timer;

        public Form1()
        {
            InitializeComponent();

            this.ballPos = new Vector(200, 200);
            this.ballSpeed = new Vector(0, 0);
            this.ballRadius = 10;

            this.timer = new Timer();
            this.timer.Interval = 10;
            this.timer.Tick += new EventHandler(Update);
            //this.timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            Gravity();
            Invalidate();
        }

        private void Gravity()
        {
            this.ballSpeed.Y += this.gravity;

            if (this.ballPos.Y + this.ballRadius + this.ballSpeed.Y > Grand(this.ballPos))
            {
                this.ballSpeed.Y = 0;
                this.ballPos.Y = Grand(this.ballPos) - this.ballRadius;
            }

            this.ballPos += this.ballSpeed;
        }

        private int Grand(Vector b)
        {
            int grand;

            grand = t.Grand(b);
            return grand;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            

            SolidBrush pinkbrush = new SolidBrush(Color.HotPink);

            float px = (float)this.ballPos.X - ballRadius;
            float py = (float)this.ballPos.Y - ballRadius;

            if (sw == 1)
            {
                e.Graphics.FillEllipse(pinkbrush, px, py, this.ballRadius * 2, this.ballRadius * 2);
                t.Draw(sender, e);
            }
            else if(sw == 0){

            }

            Image newImage = Image.FromFile(@"C:\Users\kanon\source\testC#\Gametest1\Gametest1\picture\pollman.png");

            float x = (float)this.ballPos.X - ballRadius;
            float y = (float)this.ballPos.Y - ballRadius;

            RectangleF srcRect = new RectangleF(0.0F, 0.0F, 100.0F, 200.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;

            e.Graphics.DrawImage(newImage, x, y, srcRect, units);
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            {
                //Console.WriteLine("a");
                if (this.ballSpeed.X >= -10)
                {
                    this.ballSpeed.X -= 5;
                }
            }

            if (e.KeyChar == 'd')
            {
                if(this.ballSpeed.X <= 10)
                {
                    this.ballSpeed.X += 5;
                }
            }

            if (e.KeyChar == 'w')
            {
                if (this.ballPos.Y + this.ballRadius == Grand(this.ballPos))
                {
                    this.ballPos.Y += 1;
                    this.ballSpeed.Y -= 20;
                }
            }
        }

        private void KeyUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                this.ballSpeed.X = 0;
            }

            if (e.KeyCode == Keys.D)
            {
                this.ballSpeed.X = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Button on");
            this.timer.Start();
            button1.Visible = false;
            button2.Visible = true;
            sw = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            button1.Visible = true;
            button2.Visible = false;
            sw = 0;
        }
    }
}
