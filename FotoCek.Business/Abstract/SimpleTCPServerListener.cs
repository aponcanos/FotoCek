using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.Concrete;
using FotoCek.DAL;
using FotoCek.Entities.DbClasses;
using SimpleTCP;

namespace FotoCek.Business.Abstract
{

    public class SimpleTCPServerListener : ITCPListener
    {
        SimpleTcpServer TCPListenerServer;
        private DatabaseContext _context;
        private DatabaseManager _databaseManager;
        private List<Camera> _allCameras;
        private TakeSnapshot _takeSnapshot;

        public SimpleTCPServerListener()
        {
            _context = new DatabaseContext();
            _databaseManager = new DatabaseManager();
            TCPListenerServer = new SimpleTcpServer().Start(3380);
            TCPListenerServer.DataReceived += Server_DataReceived;


            _allCameras = _databaseManager.GetList<Camera>().ToList();
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            string[] stringSeparators = new string[] { "{", "}" };
            string[] test1 = e.MessageString.Split(stringSeparators, StringSplitOptions.None);


            var connectedDeviceIP = TCPListenerServer.GetListeningIPs().FirstOrDefault();

            var ConnectedCamera = _databaseManager.GetList<Camera>().Where(x => x.IP == connectedDeviceIP.ToString()).FirstOrDefault();



            if (ConnectedCamera != null)
            {
                var eventDate = DateTime.Now;

                _takeSnapshot = new TakeSnapshot(new Camera()
                {
                    IP = ConnectedCamera.IP,
                    HTTPPort = ConnectedCamera.HTTPPort,
                    UserName = ConnectedCamera.UserName,
                    Password = ConnectedCamera.Password
                });

                Image img = _takeSnapshot.GetSnapshot(eventDate, @"c:\");

                _databaseManager.Add<MotionEvent>(new MotionEvent()
                {
                    GirisTarihi = eventDate,
                    DosyaIsmi = eventDate.ToString("yyyyMMddHHmmss"),
                    TurnikeID = ConnectedCamera.TurnikeID
                });


                TCPListenerServer.Broadcast(imageToByteArray(img));
            }



            
            var DeviceRecordingPath = (from x in _allCameras where x.IP.Equals(connectedDeviceIP) select x.RecordingPath).FirstOrDefault();

          
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
