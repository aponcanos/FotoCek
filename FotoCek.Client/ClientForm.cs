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
using FotoCek.Business.Classes.INI;
using SimpleTCP;
using Ini.Net;

namespace FotoCek.Client
{
    public partial class Form1 : Form
    {
        SimpleTcpClient client;
        public Form1()
        {
            //INIReadWrite.readWriteIniFile();
            Thread.Sleep(10000);
            InitializeComponent();

            client = new SimpleTcpClient().Connect(Ayarlar.ServerIP.ToString(), Ayarlar.ServerPort);
            client.DataReceived += Client_DataReceived;

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


        private void imgConnectionStatus_DoubleClick(object sender, EventArgs e)
        {
            client = new SimpleTcpClient().Connect(Ayarlar.ServerIP.ToString(), Ayarlar.ServerPort);
            client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            Image img = byteArrayToImage(e.Data);
            pbxGirenKisiResmi.Image = img;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void imgConnectionStatus_Click(object sender, EventArgs e)
        {

        }
    }

    
}