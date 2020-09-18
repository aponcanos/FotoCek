using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Entities.DbClasses;

namespace FotoCek.Business.Abstract
{
    public class TakeSnapshot
    {
        string IP { get; set; }
        int HTTPPort { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string SnapshotCommand { get; set; }
        public string CameraID { get; set; }
        public int TurnikeNo { get; set; }
        public string DosyaIsmi { get; set; }
        public string RecordingPath { get; set; }
        public string KaydedilecekKlasor { get; set; }
        public PictureBox pbxGelenResim { get; set; }


     
        public TakeSnapshot(Camera camera )
        {
            this.IP = camera.IP;
            this.HTTPPort = camera.HTTPPort;
            this.UserName = camera.UserName;
            this.Password = camera.Password;

            pbxGelenResim = new PictureBox();
        }

        public Image GetSnapshot(DateTime eventDate, string kameraKayitYolu)
        {
            //SONRADAN EKLENEN
            KaydedilecekKlasor = kameraKayitYolu + eventDate.ToString("yyyyMMdd") + @"\";
            DirectoryInfo directoryInfo = Directory.CreateDirectory(KaydedilecekKlasor);


            this.DosyaIsmi = eventDate.ToString("yyyyMMddHHmmss");
            pbxGelenResim.WaitOnLoad = false;
            pbxGelenResim.LoadAsync(@"http://"+ IP +":"+HTTPPort+ "/cgi-bin/image.cgi?userName="+UserName+"&password="+Password+"&cameraID=1&quality=5");
            pbxGelenResim.LoadCompleted += PbxGelenResim_LoadCompleted;
            return pbxGelenResim.Image;
        }

        private void PbxGelenResim_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ((PictureBox)sender).Image.Save(KaydedilecekKlasor + "//"+ DosyaIsmi+".jpg");
        }
    }
}
