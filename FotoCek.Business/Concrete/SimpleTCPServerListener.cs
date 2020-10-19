using FotoCek.Business.Concrete;
using FotoCek.DAL.Concrete;
using FotoCek.DAL.Concrete.EntityFramework;
using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Windows.Forms;
using FotoCek.Business.DependencyResolver;
using FotoCek.DAL.Abstract;
using Ninject;

namespace FotoCek.Business.Abstract
{
    public class SimpleTCPServerListener : SimpleTcpServer, ITCPListener
    {
        private IKernel _kernel;
        SimpleTcpServer TCPListenerServer;

        private ICameraDal _cameraManager;
        private IMotionEventDal _motionEventManager;
        private ITakeSnapshotService _takeSnapshotService;

        private List<Camera> _allCameras;




        public SimpleTCPServerListener()
        {
            _kernel = new StandardKernel(new BusinessModule());
            _cameraManager = _kernel.Get<EfCameraDal>();
            _allCameras = _cameraManager.GetCameras();
            _takeSnapshotService = _kernel.Get<TakeSnapshotManager>();

            _motionEventManager = _kernel.Get<EfMotionEventDal>();

            TCPListenerServer = new SimpleTcpServer().Start(Ayarlar.ServerPort);
            TCPListenerServer.DataReceived += Server_DataReceived;
        }




        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            var stringSeparators = new string[] { "{", "}" };
            var test1 = e.MessageString.Split(stringSeparators, StringSplitOptions.None);

            var connectedDevice = ((IPEndPoint)e.TcpClient.Client.RemoteEndPoint).Address.ToString();

            var ConnectedCamera = _allCameras.Where(x => x.IP == connectedDevice).FirstOrDefault();

            if (ConnectedCamera != null)
            {
                var eventDate = DateTime.Now;

                try
                {
                   
                    _motionEventManager.AddMotionEvent(new MotionEvent()
                    {
                        GirisTarihi = eventDate,
                        DosyaIsmi = eventDate.ToString("yyyyMMddHHmmss"),
                        TurnikeID = ConnectedCamera.TurnikeID
                    });

                    byte[] data = _takeSnapshotService.TakeSnapshot(ConnectedCamera, eventDate);


                    TCPListenerServer.Broadcast(data);

                    //var deviceRecordingPath = ConnectedCamera.RecordingPath;

                    //var DeviceRecordingPath = (from x in _allCameras where x.IP.Equals(connectedDevice) select x.RecordingPath).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }

           


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
