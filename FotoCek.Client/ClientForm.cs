using FotoCek.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FotoCek.Client
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            

            imgConnectionStatus.Parent = panel1;
            imgConnectionStatus.BackColor = Color.Transparent;

        }

        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            //Raporlama raporlama = new Raporlama();
            //raporlama.Show();
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongTimeString();
        }

        
      
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

      

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }

    
}