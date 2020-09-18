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

namespace FotoCek.Business
{
    public class ResimCek
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

        public uint m_handle { get; set; }

     
        public ResimCek(string IP, int HTTPPort, string CamUserName, string CamPass )
        {
            this.IP = IP;
            this.HTTPPort = HTTPPort;
            this.UserName = CamUserName;
            this.Password = CamPass;

            pbxGelenResim = new PictureBox();
        }

        public Image ResimGetir(DateTime girisTarihi, string kameraKayitYolu)
        {
            //SONRADAN EKLENEN
            KaydedilecekKlasor = kameraKayitYolu + girisTarihi.ToString("yyyyMMdd") + @"\";
            DirectoryInfo directoryInfo = Directory.CreateDirectory(KaydedilecekKlasor);


            this.DosyaIsmi = girisTarihi.ToString("yyyyMMddHHmmss");
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
