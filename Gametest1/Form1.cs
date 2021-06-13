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
        int gravity = 1, sw = 0;
        test1 t = new test1();
        Charactor hero = new Charactor();
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
        }

        private void Update(object sender, EventArgs e)
        {
            Wall();
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

        private void Wall()
        {
            if(this.ballPos.X + this.ballSpeed.X  <= t.RightWall(this.ballPos))
            {
                this.ballSpeed.X = 0;
                this.ballPos.X = t.RightWall(this.ballPos);
            }

            if (this.ballPos.X + this.ballSpeed.X + hero.w() >= t.LeftWall(this.ballPos))
            {
                this.ballSpeed.X = 0;
                this.ballPos.X = t.LeftWall(this.ballPos) - hero.w();
            }
        }

        private int Grand(Vector b)
        {
            int grand;

            grand = t.Grand(b);
            return grand;
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            int x = (int)this.ballPos.X;
            int y = (int)this.ballPos.Y - ballRadius;

            System.Drawing.Point ulCorner = new System.Drawing.Point(x, y - 10);

            if (sw == 1)
            {
                t.Draw(sender, e);

                hero.Draw(sender, e, ulCorner);
            }
            else if(sw == 0){

            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a')
            {
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

        private void Keyup(object sender, KeyEventArgs e)
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
