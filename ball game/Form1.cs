using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ball_game
{
    public partial class Form1 : Form
    {
        model mod = new model();

            Timer timeka = new Timer();
        public Form1()
        {
            InitializeComponent();
            timeka.Interval = 15;
            timeka.Enabled = true;
            timeka.Tick+= new System.EventHandler(this.frist_Tick);

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void frist_Tick(object sender, EventArgs e)
        {
            
            if ( mod.goLeft == true && slide.Left > 0)
            {
                slide.Left -= mod.speed;

            }
            if (mod.goRight == true && slide.Left + slide.Width < this.ClientSize.Width)
            {
                slide.Left += mod.speed;

            }
            mod.ballx += mod.x;
            mod.bally += mod.y;
            ball.Location = new Point(mod.ballx, mod.bally);
            if (mod.ballx < 0)
            {
                mod.x = -mod.x;
            }
            if (mod.ballx > this.Width - ball.Width)
            {
                mod.x = -mod.x;
            }
            if (mod.bally < 0)
            {
                mod.y = -mod.y;
            }
            if (mod.bally > this.Height - ball.Height)
            {
                mod.gameOver = true;
            }
            if(ball.Bounds.IntersectsWith(slide.Bounds))
            {
                if(mod.ballx<slide.Location.X-ball.Width +mod.x && mod.bally-ball.Height<=slide.Location.Y-slide.Height)
                {
                    mod.x = -mod.x;
                    mod.score += 1;
                    if(mod.x<0)
                    {
                        mod.x--;
                    }
                    else
                    {
                        mod.x++;
                    }


                    

                }
                if(mod.ballx>slide.Location.X + slide.Width-mod.x&& mod.bally - ball.Height <= slide.Location.Y - slide.Height)
                {
                    mod.x = -mod.x;
                    mod.score += 1;
                    if (mod.x < 0)
                    {
                        mod.x--;
                    }
                    else
                    {
                        mod.x++;
                    }



                }
                if (mod.ballx>slide.Location.X -ball.Width&&mod.ballx<slide.Location.X + slide.Width)
                {
                    mod.y = -mod.y;
                    mod.score += 1;
                    if (mod.y < 0)
                    {
                        mod.y--;
                    }
                    else
                    {
                        mod.y++;
                    }



                }

            }
                label1.Text="score:"+mod.score;
            


            if (mod.gameOver == true)
            {
                timeka.Stop();
                DialogResult result = MessageBox.Show("Game Over! \n your score is:"+mod.score+" \n Do you want to play again? ", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
            }

        }



        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                mod.goLeft = true;


            }
            if (e.KeyCode == Keys.Right)
            {

                mod.goRight = true;



            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                mod.goLeft = false;

            }
            if (e.KeyCode == Keys.Right)
            {
                mod.goRight = false;


            }
        }

    }
}
