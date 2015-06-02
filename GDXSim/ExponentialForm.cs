using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDXSim
{
    public partial class ExponentialForm : Form
    {
        public ExponentialForm()
        {
            InitializeComponent();
        }
        double xo, t, period, rate, time, y;
        Boolean decay, roundToInt;
        double[] info = new double[3];

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            info[0] = xo;
            info[1] = time;
            info[2] = rate;
            y = Algorithm.ex(domainUpDown1.Text,info);
            chart1.Series["Series1"].Points.AddXY(counter, y);

            //dicks dicks dicks
            Random rnd = new Random();
            while (panel1.Controls.Count == 0)
            {
                createfannys(Convert.ToInt32(Math.Round(y)));
            }

            counter++;
            if (counter >= time)
            {
                timer1.Stop();
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
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

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Decimal box2 = numericUpDown2.Value;
            rate = Convert.ToInt32(box2);
            box2 = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Decimal box4 = numericUpDown1.Value;
            time = Convert.ToInt32(box4);
            box4 = 0;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Decimal box1 = numericUpDown1.Value;
            xo = Convert.ToInt32(box1);
            box1 = 0;
        }

        int counter = 0;

        
    }
}
