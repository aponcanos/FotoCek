using FotoCek.DAL;
using FotoCek.Entities.DbClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace FotoCek.Business.Classes.ReadTCP
{
    public class CheckAlarmStatusOnTCP
    {
        public uint m_handle { get; set; }
        TcpClient tclient = null;
        ClientNode cNode = null;
        List<TcpClient> clients = new List<TcpClient>();

        ResimCek _resimCek;

        public string DataCache { get; set; }
        public bool AlarmVarmi { get; set; }
        DatabaseContext _databaseContext;
        public string kaydedilecekKlasor { get; set; }

        //DataBase dbIslemleri;
        TcpListener mTCPListener;

        public List<ClientNode> mlClientSocks = new List<ClientNode>();

        IPAddress ServerIP;

        TcpClient client = new TcpClient();
        public Image GelenResim { get; set; }

        public delegate void delegem(CheckAlarmStatusOnTCP sender, EventArgs e);

        public event delegem PropertyChangedEvent;
        public string DosyaIsmi { get; set; }

        public string Data { get; set; }
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


        List<Camera> TumKameralar;

        public CheckAlarmStatusOnTCP(IPAddress ServerIP, int CamTCPPort, string CamID, string CamIP, int CamHTTPPort, string CamUserName, string CamPass, string KameraResimKayitYolu, string SnapshotCommand, int TurnikeNo)
        {
            _databaseContext = new DatabaseContext();
            //_resimCek = new ResimCek();

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


            mTCPListener = new TcpListener(ServerIP, CamTCPPort);
            mTCPListener.Start();
            mTCPListener.BeginAcceptTcpClient(ClientBaglantiKur, mTCPListener);

            TumKameralar = _databaseContext.Cameras.ToList();

        }


        public async void ClientBaglantiKur(IAsyncResult iar)
        {

            TcpListener tcpl = (TcpListener)iar.AsyncState;

            try
            {
                tclient = tcpl.EndAcceptTcpClient(iar);
                tcpl.BeginAcceptTcpClient(ClientBaglantiKur, tcpl);

                var ipAdresi = ((IPEndPoint)tclient.Client.RemoteEndPoint).Address.ToString();

                Camera bagliOlanKameraIpsi = (from x in TumKameralar
                                              where x.IP.Equals(ipAdresi)
                                              select x).FirstOrDefault();

                //if (TumKameralar.Contains(bagliOlanKameraIpsi))
                //{
                //    tclient.Close();
                //}
                //else
                //{

                lock (mlClientSocks)
                {
                    mlClientSocks.Add((cNode = new ClientNode(tclient, new byte[512], new byte[512], tclient.Client.RemoteEndPoint.ToString())));
                }


                //_resimCek = new ResimCek(CamIP, CamHTTPPort, "admin", "admin");
                //GelenResim = await _resimCek.GetImageAsync();

                if (tclient.Connected)
                {
                    PropertyChangedEvent(this, null);
                }

                //}



            }
            catch (Exception exc)
            {
                EventLog.WriteEntry(exc.Message, "Errorum-2");
            }
        }
    }
}
