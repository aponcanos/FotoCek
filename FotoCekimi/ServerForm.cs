using FotoCek.Business;
using FotoCek.Business.Classes.ReadTCP;
using FotoCek.DAL;
using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.Classes.INI;
using Ini.Net;



namespace FotoCekimi
{
    public partial class ServerForm : Form
    {
        List<Camera> _allCameras;
        TcpClient _client;
        List<TcpClient> _connectedPCList, _connectedCameraList;
        Image _gonderilecekResim;
        private ResimCek _resimCek;
        //private List<string> _lstAllCamerasIPList;
        string[] _lstAllCameraIPList;
        private DatabaseContext _context;
        public string CamUserName { get; set; }
        public string CamPassword { get; set; }
        public int CamHTTPPort { get; set; }

        public IPAddress ServerIP { get; set; }
        public int ServerPort { get; set; }



        TcpListener server;
        public ServerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;


            INIReadWrite.readWriteIniFile();


            _context = new DatabaseContext();
            _lstAllCameraIPList = (from x in _context.Cameras select x.IP).ToArray();
            _connectedCameraList = new List<TcpClient>();
            _connectedPCList = new List<TcpClient>();
            _allCameras = new List<Camera>();
            _allCameras = _context.Cameras.ToList();

            this.ServerIP = Ayarlar.ServerIP;
            this.ServerPort = Ayarlar.ServerPort;

            this.CamUserName = Ayarlar.CamUserName;
            this.CamPassword = Ayarlar.CamPassword;
            this.CamHTTPPort = Ayarlar.CamHTTPPort;

            server = new TcpListener(ServerIP, ServerPort);
            server_start();

        }

        private void server_start()
        {
            server.Start();
            accept_connection();  //accepts incoming connections
        }

        private void accept_connection()
        {
            server.BeginAcceptTcpClient(handle_connection, server);  //this is called asynchronously and will run in a different thread
        }

        private void handle_connection(IAsyncResult result)  //the parameter is a delegate, used to communicate between threads
        {
            accept_connection();  //once again, checking for any other incoming connections

            _client = server.EndAcceptTcpClient(result);  //creates the TcpClient

            string connectedDeviceIP = ((IPEndPoint)_client.Client.RemoteEndPoint).Address.ToString();
            bool BaglananKameraMi = _lstAllCameraIPList.Contains(connectedDeviceIP);

            lbClients.Items.Add(_client.Client.RemoteEndPoint);

            if (BaglananKameraMi)
            {
                _connectedCameraList.Add(_client);
                _resimCek = new ResimCek(connectedDeviceIP, CamHTTPPort, CamUserName, CamPassword);

                DateTime girisTarihi = DateTime.Now;

                _context.MotionEvents.Add(new MotionEvent
                {
                    DosyaIsmi = girisTarihi.ToString("yyyyMMddHHmmss"),
                    GirisTarihi = girisTarihi,
                    TurnikeID = 1,
                });
                _context.SaveChanges();


                var DeviceRecordingPath = (from x in _allCameras where x.IP.Equals(connectedDeviceIP) select x.RecordingPath).FirstOrDefault();

                _resimCek.ResimGetir(girisTarihi, DeviceRecordingPath);
                _resimCek.pbxGelenResim.LoadCompleted += PbxGelenResim_LoadCompleted;
            }
            else
            {
                _connectedPCList.Add(_client);
            }

            NetworkStream myNetworkStream = _client.GetStream();
            byte[] myReadBuffer = new byte[_client.ReceiveBufferSize];

            myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

            var returnData = Encoding.ASCII.GetString(myReadBuffer).Replace("\0", "").ToString();


            //CLİENT GONDER DİYE KOMUT GÖNDERİRSE CEVAP OLARAK ONA RESİM YOLLA
            if (returnData == "gonder")
            {
                try
                {
                    Image RaporEkraninaGonderilecekResim = Image.FromFile("d:\\test.png");
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(_client.GetStream(), RaporEkraninaGonderilecekResim);
                    MessageBox.Show("Test");
                    //if (myNetworkStream.CanRead)
                    //{
                    //    int numberOfBytesRead = 0;

                    //    // Incoming message may be larger than the buffer size.
                    //    do
                    //    {
                    //        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);
                    //    }
                    //    while (myNetworkStream.DataAvailable);
                    //}
                    //else
                    //{

                    //}

                }
                catch (Exception ex2)
                {
                    throw ex2;
                }
                /////////////////////////////////////////////////////////////


            }


        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            Raporlama raporlama = new Raporlama();
            raporlama.Show();
        }



        private void PbxGelenResim_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            _gonderilecekResim = ((PictureBox)(sender)).Image;
            pictureBox1.Image = _gonderilecekResim;

            foreach (var itemClient in _connectedPCList)
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(itemClient.GetStream(), _gonderilecekResim);
                }
                catch (Exception)
                {

                }

            }
        }

        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongTimeString();

            int saat = DateTime.Now.Hour;
            int dakika = DateTime.Now.Minute;
            int saniye = DateTime.Now.Second;

            int count = (saat * 3600) + (dakika * 60) + saniye;

            int geriSayim = 86400 - count;

            if (geriSayim == 1)
            {
                lbClients.Items.Clear();
            }


            label1.Text = geriSayim.ToString();
        }

    }
}