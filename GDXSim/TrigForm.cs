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
    public partial class TrigForm : Form
    {
        public TrigForm()
        {
            InitializeComponent();
        }

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

        #region Variables
        double angle, HS, VS, period, amp, t;
        double trigA;
        int counter = 0;
        string trig = "sin";
        string angleS = "a";
        string HSS = "+";
        string VSS = "r";
        string periodS = "t";
        string ampS = "p";
        string tS = "t";
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] a = { counter*45, VS, HS, period, amp };
            trigA = Algorithm.CalculateFX(trig, a);
            chart1.Series["Series1"].Points.AddXY(counter*45, trigA);
            dataGridView1.Rows.Add(counter, Math.Round(trigA, 2));

            if (counter >= t)
            {
                timer1.Stop();
            }
            counter++;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Decimal box1 = numericUpDown1.Value;
            period = Convert.ToInt32(box1);
            label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            box1 = 0;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Decimal box2 = numericUpDown2.Value;
            amp = Convert.ToInt32(box2);
            label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            box2 = 0;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Decimal box3 = numericUpDown1.Value;
            HS = Convert.ToInt32(box3);
            label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            box3 = 0;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Decimal box4 = numericUpDown1.Value;
            VS = Convert.ToInt32(box4);
            label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            box4 = 0;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Decimal box5 = numericUpDown1.Value;
            t = Convert.ToInt32(box5);
            label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            box5 = 0;
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (domainUpDown1.Text.Equals("cos"))
            {
                trig = "cos";
                label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            }
            else if (domainUpDown1.Text.Equals("tan"))
            {
                trig = "tan";
                label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            }
            else if (domainUpDown1.Text.Equals("sin"))
            {
                trig = "sin";
                label8.Text = "y=" + ampS + " " + trig + "(" + t + "/" + period + "-" + HS + ")+" + VS;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            chart1.Series["Series1"].Points.Clear();
            dataGridView1.Rows.Clear();
            counter = 0;
            trigA = 0;
        }

        

        

    }
}
