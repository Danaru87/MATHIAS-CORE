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
        private MathiasCore matCore;
        private Thread InitialisationThread;
        public Form1()
        {
            InitializeComponent();
            
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
                label4.Text = "";
                Mathias_Manager window = new Mathias_Manager(matCore);
                window.Location = this.Location;
                window.StartPosition = FormStartPosition.Manual;
                window.FormClosing += delegate { this.Show(); };
                window.Show();
                this.Hide();
            }
        }

        private void Form1_Show(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            btnQuit.Enabled = false;
            txtUsername.Enabled = false;
            txtPass.Enabled = false;
            label4.Text = "Mathias est en cours d'initialisation, veuillez patienter...";

            InitialisationThread = new Thread(InitMathias);
            InitialisationThread.Name = "InitialisationThread";
            InitialisationThread.Start();
            
            InitialisationThread.Join();
            btnConnect.Enabled = true;
            btnQuit.Enabled = true;
            txtUsername.Enabled = true;
            txtPass.Enabled = true;
            label4.Text = "Mathias est prêt, vous pouvez vous connecter";
        }

        private void InitMathias()
        {
            matCore = new MathiasCore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
