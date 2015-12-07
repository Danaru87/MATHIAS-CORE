using MCORE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinConfigurator
{
    public partial class Form1 : Form
    {
        public MathiasCore matCore;
        public Form1()
        {
            InitializeComponent();
            matCore = new MathiasCore();
        }

        private bool Connect()
        {
            bool connected = matCore.Connect(txtUsername.Text, txtPass.Text);
            if (connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            label4.Text = "Connexion en cours ....";
            bool connected = Task.Factory.StartNew(() => Connect()).Result;
            if (connected)
            {

                Mathias_Manager window = new Mathias_Manager(matCore);
                window.Location = this.Location;
                window.StartPosition = FormStartPosition.Manual;
                window.FormClosing += delegate { this.Show(); };
                window.Show();
                this.Hide();
            }
        }
    }
}
