using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinConfigurator
{
    public partial class Mathias_Manager : Form
    {
        public Mathias_Manager(MCORE.MathiasCore matCore)
        {
            InitializeComponent();
        }

        private void Mathias_Manager_Load(object sender, EventArgs e)
        {   
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
