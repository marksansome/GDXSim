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
    public partial class GeometryForm : Form
    {
        double length = 0 , width = 0, height = 0, bas = 0, radius = 0, answer = 0;

        // initialize form , hide panels 
        public GeometryForm()
        {
            InitializeComponent();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
        }

        // initialize panels 
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            panel2.Hide();

        }


        //rektangle 

        // initialize width and length variables
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Decimal box2 = numericUpDown2.Value;
            width = Convert.ToDouble(box2);
            box2 = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Decimal box1 = numericUpDown1.Value;
            length = Convert.ToDouble(box1);
            box1 = 0;
        }  

        private void button4_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.Text == "Area")
            {
                answer = length * width;
            }
            else if (domainUpDown1.Text == "Perimeter")
            {
                answer = (length + width) * 2; 
            }

            label4.Text = Convert.ToString(Math.Round(answer,2));
        }

        




        // circle 
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Decimal box3 = numericUpDown3.Value;
            radius = Convert.ToDouble(box3);
            box3 = 0;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (domainUpDown2.Text == "Area")
            {
                answer = Math.PI * Math.Pow(radius, 2);
                
            }
            else if (domainUpDown2.Text == "Perimeter")
            {
                answer = 2 * Math.PI * radius;
                
            }

            label5.Text = Convert.ToString(Math.Round(answer,2));
        }


        // Tr-eye-angle
        private void button6_Click(object sender, EventArgs e)
        {
            if (domainUpDown3.Text == "Area")
            {
                answer = (bas * height) / 2;
            }
            label7.Text = Convert.ToString(Math.Round(answer, 2));
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Decimal box5 = numericUpDown5.Value;
            height = Convert.ToDouble(box5);
            box5 = 0;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Decimal box4 = numericUpDown4.Value;
            bas = Convert.ToDouble(box4);
            box4 = 0;
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector();
            selector.Show();
            this.Hide();
        }

        private void tutorialsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }

}
