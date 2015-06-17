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
using System.Diagnostics;
using System.Reflection;

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
        double xo, t, period, rate, r100;
        double fx;
        int counter = 0;
        string ex = "growth";
        string a = "a";
        string sign = "+";
        string r = "r";
        string sT = "t";
        string p = "p";
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            double [] a = {xo, counter, period, rate};
            fx = Algorithm.CalculateFX(ex, a);
            chart1.Series["Series1"].Points.AddXY(counter,fx);
            dataGridView1.Rows.Add(counter, Math.Round(fx, 2));
            //createfannys(Convert.ToInt32(fx));
            
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
            a = Convert.ToString(xo);
            label8.Text = "y="+ a + "(1" + sign +  r + ")^(" + sT + "/" + p + ")";
            box1 = 0;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Decimal box3 = numericUpDown3.Value;
            period = Convert.ToInt32(box3);
            p = Convert.ToString(period);
            label8.Text = "y=" + a + "(1" + sign + r + ")^(" + sT + "/" + p + ")";
            box3 = 0;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Decimal box4 = numericUpDown4.Value;
            t = Convert.ToInt32(box4);
            sT = Convert.ToString(t);
            label8.Text = "y=" + a + "(1" + sign + r + ")^(" + sT + "/" + p + ")";
            box4 = 0;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Decimal box2 = numericUpDown2.Value;
            rate = Convert.ToInt32(box2);
            r100 = rate / 100;
            r = Convert.ToString(r100);
            label8.Text = "y=" + a + "(1" + sign + r + ")^(" + sT + "/" + p + ")";
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
                sign = "-";
                label8.Text = "y=" + a + "(1" + sign + r + ")^(" + sT + "/" + p + ")";
            }
            else if (domainUpDown1.Text.Equals("Growth"))
            {
                ex = "growth";
                sign = "+";
                label8.Text = "y=" + a + "(1" + sign + r + ")^(" + sT + "/" + p + ")";
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
            dataGridView1.Rows.Clear();
            counter = 0;
            fx = 0;
            //panel1.Controls.Clear();
            fannys.Clear();
        }
        #endregion

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector();
            selector.Show();
            this.Hide();
        }

        private void tutorialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tutorials tutorial = new Tutorials();
            tutorial.Show();
            this.Hide();
        }
    }
}

