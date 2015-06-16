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
    }
}
