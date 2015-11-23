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
        Thread connectThread;
        public Form1()
        {
            InitializeComponent();
            matCore = new MathiasCore();
        }

        private void Connect()
        {
            btnConnect.Invoke(new Action(() => btnConnect.Enabled = false ));
            bool connected = matCore.Connect(txtUsername.Text, txtPass.Text);
            if (connected)
            {
                label3.Invoke(new Action(() => label3.Text = "Connected !"));
            }
            else
            {
                btnConnect.Invoke(new Action(() => btnConnect.Enabled = true));
                label3.Invoke(new Action(() => label3.Text = "Failed !"));
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connectThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectThread = new Thread(Connect);
        }
    }
}
