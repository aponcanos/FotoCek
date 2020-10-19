using System;
using System.Collections.Generic;
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

        public byte[] TakeSnapshot(Camera camera, DateTime eventDate)
        {
            byte[] data;

            using (WebClient client = new WebClient())
            {
                NetworkCredential nc = new NetworkCredential(camera.UserName,camera.Password);
                client.Credentials = nc;

                data = client.DownloadData("http://"+ camera.IP + ":" + camera.HTTPPort + camera.SnapshotCommand);

                DirectoryInfo result =
                    Directory.CreateDirectory(camera.RecordingPath + @"\" + camera.CameraName + @"\");


                Image res = ByteArrayToImage(data);
                res.Save(result.FullName + eventDate.ToString("yyyyMMddHHmmss") + ".jpg");
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
