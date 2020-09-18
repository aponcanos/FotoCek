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
        TcpClient _client;
        public IPAddress ServerIP { get; set; }
        public int ServerPort { get; set; }
        public bool IsConnectedToServer { get; set; } = false;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            Thread.Sleep(3000);
            this.ServerIP = Ayarlar.ServerIP;
            this.ServerPort = Ayarlar.ServerPort;

            imgConnectionStatus.Parent = panel1;
            imgConnectionStatus.BackColor = Color.Transparent;

        }

        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            Raporlama raporlama = new Raporlama(_client);
            raporlama.Show();
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongTimeString();
        }


        Socket s;
        private void StartReading()
        {
            try
            {
                //Client sunucuya bağlandıktan sonra bir mesaj göndermesi lazım ki sunucu sürekli bekleme modundan çıksın
                string message = "test";
                Byte[] data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream2 = _client.GetStream();
                stream2.Write(data, 0, data.Length);
                s = _client.Client;

                while (SocketExtensions.IsConnected(s))
                {
                    NetworkStream stream = _client.GetStream();
                    BinaryFormatter formatter = new BinaryFormatter();
                    Image img = (Image)formatter.Deserialize(stream);
                    pbxGirenKisiResmi.Image = img; //Show the image in the picturebox
                }
            }
            catch (Exception)
            {
                IsConnectedToServer = false;
                //MessageBox.Show("Client Disconnect oldu");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    _client = new TcpClient();
                    _client.Connect(ServerIP, ServerPort);

                    IsConnectedToServer = true;
                    StartReading();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sunucuyla bağlantı sağlanamadı. Lütfen sunucunun çalışıyor olduğuna emin olun", "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();

                    _client.Close();
                }
            }).Start();
        }

      

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Close();
        }
    }

    static class SocketExtensions
    {
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Available == 0 && socket.Poll(1, SelectMode.SelectRead));
                //return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }


    }
}