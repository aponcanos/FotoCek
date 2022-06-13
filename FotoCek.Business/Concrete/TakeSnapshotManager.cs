using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Business.Abstract;
using FotoCek.Entities;
using FotoCek.Entities.DbClasses;

namespace FotoCek.Business.Concrete
{
    public class TakeSnapshotManager : ITakeSnapshotService
    {

        public void TakeSnapshotAsync(Camera camera, DateTime eventDate, string RecordingPath)
        {
            using (WebClient client = new WebClient())
            {
                NetworkCredential nc = new NetworkCredential(camera.UserName, camera.Password);
                client.Credentials = nc;

                client.DownloadFileTaskAsync(new Uri("http://192.168.0.27/cgi-bin/image.cgi?userName=admin&password=admin&cameraID=1&quality=5"), $@"{RecordingPath}\{eventDate.Millisecond}.png");
                //client.DownloadFileCompleted += Client_DownloadFileCompleted;
            }
        }

        public byte[] TakeSnapshot(Camera camera, DateTime eventDate)
        {
            byte[] data;

            using (WebClient client = new WebClient())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                NetworkCredential nc = new NetworkCredential(camera.UserName, camera.Password);
                client.Credentials = nc;

                data = client.DownloadData("http://" + camera.IP + ":" + camera.HTTPPort + camera.SnapshotCommand);
                //data = client.DownloadFileAsync(new Uri("http://" + camera.IP + ":" + camera.HTTPPort + camera.SnapshotCommand),"e2" );


                DirectoryInfo result = Directory.CreateDirectory(camera.RecordingPath + @"\" + camera.CameraName + @"\");


                Image res = ByteArrayToImage(data);
                res.Save(result.FullName + eventDate.ToString("yyyyMMddHHmmss") + ".jpg");

                sw.Stop();
            }

            return data;
        }

        public Image ByteArrayToImage(byte[] data)
        {
            MemoryStream bipimag = new MemoryStream(data);
            Image imag = new Bitmap(bipimag);
            return imag;
        }


    }
}
