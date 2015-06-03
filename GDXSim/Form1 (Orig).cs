using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        List<PictureBox> fannys = new List<PictureBox>();

        #region Set image and sound
        String[,] types = new String[,] { { "C:/Users/marks/Documents/Visual Studio 2015/Projects/GDXSim/WindowsFormsApplication4/Cases/Fanny/img.jpg", "C:/Users/marks/Documents/Visual Studio 2015/Projects/GDXSim/WindowsFormsApplication4/Cases/Fanny/sound.wav" }, { "C:/Users/marks/Documents/Visual Studio 2015/Projects/GDXSim/WindowsFormsApplication4/Cases/Cash/img.jpg", "C:/Users/marks/Documents/Visual Studio 2015/Projects/GDXSim/WindowsFormsApplication4/Cases/Bacteria/sound.wav" }, { "C:/Users/marks/Documents/Visual Studio 2015/Projects/GDXSim/WindowsFormsApplication4/Cases/Monkeys/img.jpg", "C:/Users/marks/Documents/Visual Studio 2015/Projects/GDXSim/WindowsFormsApplication4/Cases/Monkeys/sound.wav" } };
        String[] current1 = new String[2] { "/Cases/Fanny/img.jpg", "/Cases/Fanny/sound.wav" };
        int imageCounter = 0;
        public void switchCurrent()
        {
            current1[1] = types[imageCounter, 1];
            current1[0] = types[imageCounter, 0];
        }
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Variables
        Boolean decay, roundToInt;
        double xo, t, period, rate, y;
        int counter = 0;
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            double oldFx = Equation.fx;
            y = Equation.CalculateFx(decay, xo, counter, period, rate);
            chart1.Series["Series1"].Points.AddXY(counter,y);

            if (counter % 5 == 0)
            {
                SoundPlayer simpleSound = new SoundPlayer("C:/Users/marks/Desktop/sound.wav");
                simpleSound.Play();
            }

            Random rnd = new Random();
            
            if (decay)
            {
                destroyfannys( Convert.ToInt32(Math.Round(y)), Convert.ToInt32(Math.Round(Equation.CalculateFx(decay, xo, (counter - 1), 1, rate))));
            }
            else
            {
                growfannys(rnd, Convert.ToInt32(Math.Round(y)), Convert.ToInt32(Math.Round(Equation.CalculateFx(decay, xo, (counter - 1), 1, rate))));
            }

            if (counter >= t)
            {
               timer1.Stop();
            }
            counter++;
        }
        #endregion

        #region Form options
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Decimal box1 = numericUpDown1.Value;
            xo = Convert.ToInt32(box1);
            box1 = 0;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Decimal box3 = numericUpDown3.Value;
            period = Convert.ToInt32(box3);
            box3 = 0;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Decimal box4 = numericUpDown4.Value;
            t = Convert.ToInt32(box4);
            box4 = 0;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Decimal box2 = numericUpDown2.Value;
            rate = Convert.ToInt32(box2);
            box2 = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            period = 1;
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            if (domainUpDown2.Text.Equals("Fanny"))
            {
                imageCounter = 0;
                switchCurrent();
            }
            else if (domainUpDown2.Text.Equals("Monkey"))
            {
                imageCounter = 3;
                switchCurrent();
            }
            else if (domainUpDown2.Text.Equals("Bacteria"))
            {
                imageCounter = 2;
                switchCurrent();
            }
            else if (domainUpDown2.Text.Equals("Cash"))
            {
                imageCounter = 1;
                switchCurrent();
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)//Growth/Decay
        {
            if (domainUpDown1.Text.Equals("Decay"))
            {
                decay = true;
            }
            else if (domainUpDown1.Text.Equals("Growth"))
            {
                decay = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)//Generate
        {
            timer1.Start();
            Random rnd = new Random();
            spawnfannys(Convert.ToInt32(Math.Round(xo)), rnd);
        }

        private void button1_Click(object sender, EventArgs e)//Reset
        {
            timer1.Stop();
            chart1.Series["Series1"].Points.Clear();
            counter = 0;
            
            y = 0;
            panel1.Controls.Clear();
            fannys.Clear();
        }
#endregion

        #region displaying images
        public void spawnfannys(int i, Random rnd)
        {
            for (int j = 0; j < i; j++)
            {
                int[] x = new int[i];
                int[] y = new int[i];
                double q = 50;
                PictureBox pictureBox = new System.Windows.Forms.PictureBox();
                fannys.Add(pictureBox);
                x[j] = rnd.Next(0, 277);
                y[j] = rnd.Next(0, 385);

                pictureBox.Location = new System.Drawing.Point(x[j], y[j]);
                pictureBox.Name = "fanny" + i;
                if (i > 20)
                {
                    q = 50 * (.005 * i);
                }

                pictureBox.Size = new System.Drawing.Size(30, 30);
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                pictureBox.Parent = panel1;
                pictureBox.Image = global::WindowsFormsApplication4.Properties.Resources.img;
            }
        }
        public void growfannys( Random rnd,int current, int previous)
        {
            int now = current - previous;
            for (int j = 0; j < now; j++)
            { 
                int[] x = new int[now];
                int[] y = new int[now];
                double q = 50;
                PictureBox pictureBox = new System.Windows.Forms.PictureBox();
                fannys.Add(pictureBox);
                x[j] = rnd.Next(0, 277);
                y[j] = rnd.Next(0, 385);

                pictureBox.Location = new System.Drawing.Point(x[j], y[j]);
                pictureBox.Name = "fanny" + now;
                if (now > 20)
                {
                    q = 50 * (.005 * now);
                }

                pictureBox.Size = new System.Drawing.Size(30, 30);
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                pictureBox.Parent = panel1;
                pictureBox.Image = global::WindowsFormsApplication4.Properties.Resources.img;
            }
        }


        public void destroyfannys(int current, int previous )
        {

            int now = previous - current;
                while (now > 0 && panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
                now--;
            }
            while (now > 0 && panel1.Controls.Count > 0)
            {
                fannys.RemoveAt(0);
                now--;
            }
        }
        #endregion

    }
}

