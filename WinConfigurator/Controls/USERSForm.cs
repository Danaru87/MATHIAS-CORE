using COREDB;
using MCORE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinConfigurator.Controls
{
    public partial class USERSForm : Form
    {
        private MathiasCore matCore {get; set;}
        public USERSForm(MCORE.MathiasCore pmatCore)
        {
            InitializeComponent();
            matCore = pmatCore;
        }

        private void USERSForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Loading user list";

        }
    }
}
