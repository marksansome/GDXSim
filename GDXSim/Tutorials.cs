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
    public partial class Tutorials : Form
    {
        public Tutorials()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new System.Uri("http://www.mathsisfun.com/algebra/exponential-growth.html", System.UriKind.Absolute);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new System.Uri("http://www.mathsisfun.com/algebra/trigonometry.html", System.UriKind.Absolute);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new System.Uri("https://www.mathsisfun.com/geometry/index.html", System.UriKind.Absolute);
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selector selector = new Selector();
            selector.Show();
            this.Hide();
        }
    }
}
