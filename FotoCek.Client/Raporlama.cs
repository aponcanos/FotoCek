using FotoCek.Business.Classes;
using FotoCek.DAL;
using FotoCek.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.Concrete;
using FotoCek.Business.DependencyResolver;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete;
using FotoCek.DAL.Concrete.EntityFramework;
using FotoCek.DAL.Concrete.ORM.EntityFramework;
using Ninject;

namespace FotoCek.Client
{
    public partial class Raporlama : Form
    {
        private IMotionEventDal _motionEventManager;
        private ITurnstileDal _turnstileManager;
        private ICameraDal _cameraManager;
        private IKernel _kernel;


        DatabaseContext _databaseContext;


        public Raporlama()
        {
            InitializeComponent();
            _kernel = new StandardKernel(new BusinessModule());

            _motionEventManager = _kernel.Get<EfMotionEventDal>();
            _turnstileManager = _kernel.Get<EfTurnstileDal>();
            _cameraManager = _kernel.Get<EfCameraDal>();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            if (drpTurnstile.Text == "")
            {
                var tables = from camera in _cameraManager.GetCameras()
                             join turnstile in _turnstileManager.GetTurnstiles() on camera.TurnikeID equals turnstile.Id
                             join motionEvent in _motionEventManager.GetMotionEvents() on turnstile.Id equals motionEvent.TurnikeID
                             where motionEvent.GirisTarihi > dtBaslangicZamani.Value && motionEvent.GirisTarihi < dtBitisZamani.Value
                             select new
                             {
                                 camera.RecordingPath,
                                 camera.CameraName,
                                 camera.Location,
                                 turnstile.Name,
                                 motionEvent.GirisTarihi,
                                 turnstile.Id
                             };

                grdMotionEvents.DataSource = tables;
            }
            else
            {
                var tables = from camera in _cameraManager.GetCameras()
                             join turnstile in _turnstileManager.GetTurnstiles() on camera.TurnikeID equals turnstile.Id
                             join motionEvent in _motionEventManager.GetMotionEvents() on turnstile.Id equals motionEvent.TurnikeID
                             where turnstile.Name == drpTurnstile.Text
                             where motionEvent.GirisTarihi > dtBaslangicZamani.Value && motionEvent.GirisTarihi < dtBitisZamani.Value
                             select new
                             {
                                 camera.RecordingPath,
                                 camera.CameraName,
                                 camera.Location,
                                 turnstile.Name,
                                 motionEvent.GirisTarihi,
                                 turnstile.Id
                             };

                grdMotionEvents.DataSource = tables;

            }


            lblToplam.Text = grdMotionEvents.Rows.Count.ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.startExport(grdMotionEvents);

        }
       

        private void drpPlakaKonumu_Click(object sender, EventArgs e)
        {
            drpTurnstile.DataSource = _turnstileManager.GetTurnstiles();
            drpTurnstile.ValueMember = "Name";
            drpTurnstile.DisplayMember = "Name";
        }


        private string imagePath = "";
        private void grdMotionEvents_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                var selectedRow = grdMotionEvents.SelectedRows;

                var kYolu = selectedRow[0].Cells["RecordingPath"].Value.ToString();
                string GirisTarihi = Convert.ToDateTime(selectedRow[0].Cells["GirisTarihi"].Value).ToString("yyyyMMddHHmmss");
                string camName = selectedRow[0].Cells["CameraName"].Value.ToString();


                imagePath = kYolu + @"\" + camName + @"\" + GirisTarihi + ".jpg";

                pctImage.Image = Image.FromFile(imagePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Resim bulunamadı.", "Resim Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pctImage_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(imagePath);

        }
    }
}
