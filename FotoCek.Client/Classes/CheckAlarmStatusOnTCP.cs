using FotoCek.Business.Classes.ReadTCP;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoCek.Client.Classes
{
    public class CheckAlarmStatusOnTCP
    {
        public Image NetworkdenGelenResim { get; set; }
        public string DataCache { get; set; }
        public bool AlarmVarmi { get; set; }
        public string kaydedilecekKlasor { get; set; }

        //DataBase dbIslemleri;
        TcpListener mTCPListener;

        public List<ClientNode> mlClientSocks = new List<ClientNode>();

        IPAddress ServerIP;

        TcpClient client = new TcpClient();

        public delegate void delegem(CheckAlarmStatusOnTCP sender, EventArgs e);

        public event delegem PropertyChangedEvent;
        public string DosyaIsmi { get; set; }

        string _data;
        public string Data
        {
            get
            {
                return _data;
            }

            set
            {
                if (value != _data)
                {
                    this._data = value;

                    //PropertyChangedEvent(this, null);
                }
            }
        }
        public string KameraKonumu { get; set; }
        public string CamIP { get; set; }
        public string CamUserName { get; set; }
        public string CamPass { get; set; }
        public int CamTCPPort { get; set; }
        public int CamHTTPPort { get; set; }
        public string KameraResimKayitYolu { get; set; }
        public string Lokasyon { get; set; }
        public string CamID { get; set; }
        public string PeronNo { get; set; }
        public string AlarmCheckCommand { get; set; }
        public string SnapshotCommand { get; set; }
        public int TurnikeNo { get; set; }

        public CheckAlarmStatusOnTCP(IPAddress ServerIP, int CamTCPPort, string CamID, string CamIP, int CamHTTPPort, string CamUserName, string CamPass, string KameraResimKayitYolu, string SnapshotCommand, int TurnikeNo)
        {
            this.ServerIP = ServerIP;
            this.CamTCPPort = CamTCPPort;

            this.CamID = CamID;
            this.CamIP = CamIP;
            this.CamHTTPPort = CamHTTPPort;
            this.CamUserName = CamUserName;
            this.CamPass = CamPass;
            this.KameraResimKayitYolu = KameraResimKayitYolu;
            this.SnapshotCommand = SnapshotCommand;
            this.TurnikeNo = TurnikeNo;


            //dbIslemleri = new DataBase();

            mTCPListener = new TcpListener(ServerIP, CamTCPPort);

            mTCPListener.Start();

            mTCPListener.BeginAcceptTcpClient(ClientBaglantiKur, mTCPListener);
        }

        public void ClientBaglantiKur(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            TcpClient tclient = null;
            ClientNode cNode = null;

            try
            {
                tclient = tcpl.EndAcceptTcpClient(iar);
                tcpl.BeginAcceptTcpClient(ClientBaglantiKur, tcpl);

                lock (mlClientSocks)
                {
                    mlClientSocks.Add((cNode = new ClientNode(tclient, new byte[512], new byte[512], tclient.Client.RemoteEndPoint.ToString())));
                }

                tclient.GetStream().BeginRead(cNode.Rx, 0, cNode.Rx.Length, onVeriCek, tclient);
            }
            catch (Exception exc)
            {
                EventLog.WriteEntry(exc.Message, "Errorum-2");
            }
        }



        public void onVeriCek(IAsyncResult iar)
        {
            ClientNode clientNod = null;
            TcpClient tcpc;
            int nCountReadBytes = 0;



            try
            {
                lock (mlClientSocks)
                {

                    tcpc = (TcpClient)iar.AsyncState;

                    clientNod = mlClientSocks.Find(x => x.strId == tcpc.Client.RemoteEndPoint.ToString());


                    //nCountReadBytes = tcpc.GetStream().EndRead(iar);

                    NetworkStream ns = tcpc.GetStream();

                    nCountReadBytes = ns.EndRead(iar);

                    if (nCountReadBytes == 0)// this happens when the client is disconnected
                    {
                        mlClientSocks.Remove(clientNod);

                        return;
                    }

                    Data = Encoding.ASCII.GetString(clientNod.Rx, 0, nCountReadBytes).Trim();


                  
                    MessageBox.Show(Data);


                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Error1", ex.Message + "hatası oluştu");

                lock (mlClientSocks)
                {
                    mlClientSocks.Remove(clientNod);
                    //lbClients.Items.Remove(cn.ToString());
                }

            }
        }

        private void StartReading()
        {

        }
    }
}
