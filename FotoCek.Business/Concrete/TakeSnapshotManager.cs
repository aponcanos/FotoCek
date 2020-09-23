using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Business.Abstract;
using FotoCek.Entities.DbClasses;

namespace FotoCek.Business.Concrete
{
    public class TakeSnapshotManager:ITakeSnapshotService
    {
        string IP { get; set; }
        int HTTPPort { get; set; }
        string UserName { get; set; }
        string Password { get; set; }

        public TakeSnapshotManager(Camera camera)
        {
            this.IP = camera.IP;
            this.HTTPPort = camera.HTTPPort;
            this.UserName = camera.UserName;
            this.Password = camera.Password;
        }

        public byte[] TakeSnapshot(Camera camera, DateTime eventDate)
        {
            byte[] data;

            using (WebClient client = new WebClient())
            {
                data = client.DownloadData($"http://{camera.IP}:{camera.HTTPPort}/cgi-bin/image.cgi?userName={camera.UserName}&password={camera.Password}&cameraID=1&quality=5");
            }

            return data;
        }
    }
}
