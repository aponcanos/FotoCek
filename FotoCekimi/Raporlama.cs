using FotoCek.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.DAL.Concrete.EntityFramework;

namespace FotoCekimi
{
    public partial class Raporlama : Form
    {
        DatabaseContext _databaseContext;

        public string DosyaYolu { get; set; }
        public string YazdirilacakResimYolu { get; set; }

        public Raporlama()
        {
            InitializeComponent();
            _databaseContext = new DatabaseContext();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            var bulunanSonuclar = _databaseContext.MotionEvents.Where(x => x.GirisTarihi > dtBaslangicZamani.Value && x.GirisTarihi < dtBitisZamani.Value).ToList();
            grdRapor.DataSource = bulunanSonuclar;

            lblToplam.Text = grdRapor.Rows.Count.ToString();
        }

        private void grdRapor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = grdRapor.SelectedRows;

                int ID = Convert.ToInt32(selectedRow[0].Cells["ID"].Value);
                string GirisTarihi = Convert.ToDateTime(selectedRow[0].Cells["GirisTarihi"].Value).ToString("yyyyMMdd");
                int TurnikeID = Convert.ToInt32(selectedRow[0].Cells["TurnikeID"].Value);
                var DosyaIsmi = selectedRow[0].Cells["DosyaIsmi"].Value;

                var KameraKayitYolu = (_databaseContext.Cameras.Single(x => x.TurnikeID == TurnikeID)).RecordingPath;

                //////CLİENT MAKİNALARINA KURULUM YAPILINCA BU satırı ekliyorum. Sunucu da üst satırı açıp alt satırı silmem lazım. 

                ////string KantarKameraKayitYolu = @"\\10.87.8.9\Turnike\T1\";


                var TurnikeKameraDosyaIsmi = (_databaseContext.MotionEvents.Single(x => x.ID == ID)).DosyaIsmi;

                 YazdirilacakResimYolu = @KameraKayitYolu + @GirisTarihi + @"\" + TurnikeKameraDosyaIsmi + ".jpg";

                pctGirenKisiResmi.Image = Image.FromFile(@YazdirilacakResimYolu);


            }
            catch (Exception)
            {
                MessageBox.Show("Resim bulunamadı.", "Resim Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
            Process.Start(YazdirilacakResimYolu);
        }

        private void pctGirenKisiResmi_DockChanged(object sender, EventArgs e)
        {

        }
    }
}
