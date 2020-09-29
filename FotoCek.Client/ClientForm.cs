using FotoCek.Entities;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using FotoCek.Business.Concrete;
using FotoCek.Client.Properties;
using FotoCek.DAL.Abstract;
using FotoCek.Entities.DbClasses;

namespace FotoCek.Client
{
    public partial class Form1 : Form
    {
        private List<Camera> _allCameras;
        SimpleTcpClient client;
        private ICameraDal _cameraManager;

        public Form1()
        {
            INIReadWrite.readWriteIniFile();
            Thread.Sleep(2000);
            InitializeComponent();

            connectToServer();

            imgConnectionStatus.Parent = panel1;
            imgConnectionStatus.BackColor = Color.Transparent;
        }


        private void connectToServer()
        {
            //INIReadWrite.readWriteIniFile();
            try
            {
                if ((client==null) || (!client.TcpClient.Connected))
                {
                    client = new SimpleTcpClient().Connect(Ayarlar.ServerIP.ToString(), Ayarlar.ServerPort);
                    client.DataReceived += Client_DataReceived;

                    imgConnectionStatus.Image = Resources.green1;
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Sunucuya bağlanamadı !", "Bağlantı Hatası", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                imgConnectionStatus.Image = Resources.red1;
            }

           

        }
        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            Raporlama raporlama = new Raporlama();
            raporlama.Show();
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongTimeString();
        }


        private void imgConnectionStatus_DoubleClick(object sender, EventArgs e)
        {
            connectToServer();

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