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

namespace GDXSim
{
    public partial class ExponentialForm : Form
    {
        List<PictureBox> fannys = new List<PictureBox>();

        public ExponentialForm()
        {
            InitializeComponent();
        }

        #region Variables
        Boolean decay, roundToInt;
        double xo, t, period, rate;
        int fx;
        int counter = 0;
        string ex = "growth";
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            double [] a = {xo, counter, period, rate};
            
            //double oldFx = GDXSim.Algorithm.fx;
            //y = GDXSim.Algorithm.CalculateFX();
            fx = Algorithm.CalculateFX(ex, a);
            Console.WriteLine(fx);
            chart1.Series["Series1"].Points.AddXY(counter, fx);

            Random rnd = new Random();
            createfannys(fx);
            
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

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)//Growth/Decay
        {
            if (domainUpDown1.Text.Equals("Decay"))
            {
                ex = "decay";
            }
            else if (domainUpDown1.Text.Equals("Growth"))
            {
                ex = "growth";
            }
        }

        private void button2_Click(object sender, EventArgs e)//Generate
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)//Reset
        {
            timer1.Stop();
            chart1.Series["Series1"].Points.Clear();
            counter = 0;

            fx = 0;
            panel1.Controls.Clear();
            fannys.Clear();
        }
        #endregion

    }
}

