using FotoCek.Business.Classes;
using FotoCek.DAL;
using FotoCek.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.DependencyResolver;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete.EntityFramework;
using Ninject;

namespace FotoCek.Client
{
    public partial class Raporlama : Form
    {
        private IMotionEventDal _motionEventManager;
        private IKernel _kernel;

        DatabaseContext _databaseContext;
        

        public Raporlama()
        {
            InitializeComponent();
            _kernel=new StandardKernel(new BusinessModule());
            _motionEventManager = _kernel.Get<EfMotionEventDal>();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
          var MotionEventList =  _motionEventManager.GetMotionEvents().Where(x => x.GirisTarihi > dtBaslangicZamani.Value && x.GirisTarihi < dtBitisZamani.Value).ToList();
           
            grdRapor.DataSource = MotionEventList;

            lblToplam.Text = grdRapor.Rows.Count.ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xlsx)|*.xlsx";
            sfd.FileName = "export.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string stOutput = "";
                string sHeaders = "";

                for (int j = 0; j < grdRapor.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(grdRapor.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";

                for (int i = 0; i < grdRapor.RowCount; i++)
                {
                    string stLine = "";
                    for (int j = 0; j < grdRapor.Rows[i].Cells.Count; j++)
                        stLine = stLine.ToString() + Convert.ToString(grdRapor.Rows[i].Cells[j].Value) + "\t";
                    stOutput += stLine + "\r\n";
                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();

                MessageBox.Show("Veriler Excel olarak kaydedildi", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void pctGirenKisiResmi_DoubleClick(object sender, EventArgs e)
        {
        }

        private void grdRapor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    var selectedRow = grdRapor.SelectedRows;

            //    int ID = Convert.ToInt32(selectedRow[0].Cells["ID"].Value);
            //    string GirisTarihi = Convert.ToDateTime(selectedRow[0].Cells["GirisTarihi"].Value).ToString("yyyyMMdd");
            //    int TurnikeID = Convert.ToInt32(selectedRow[0].Cells["TurnikeID"].Value);
            //    var DosyaIsmi = selectedRow[0].Cells["DosyaIsmi"].Value;

            //    var KameraKayitYolu = (_databaseContext.Cameras.Single(x => x.TurnikeID == TurnikeID)).RecordingPath;

            //    var TurnikeKameraDosyaIsmi = (_databaseContext.MotionEvents.Single(x => x.ID == ID)).DosyaIsmi;
               
            //    YazdirilacakResimYolu = @KameraKayitYolu + GirisTarihi + @"\" + TurnikeKameraDosyaIsmi + ".jpg";

            //    pctGirenKisiResmi.Image = Image.FromFile(@YazdirilacakResimYolu);

            //    //Serverdan üzerine tıklanılan resmi istemek için istek gönder
            //    getData.GetDataFromServer(tcpClient, YazdirilacakResimYolu);

                

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Resim bulunamadı.", "Resim Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
