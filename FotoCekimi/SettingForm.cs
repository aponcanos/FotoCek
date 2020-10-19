﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.DependencyResolver;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete;
using FotoCek.DAL.Concrete.ORM.EntityFramework;
using FotoCek.Entities.Concrete;
using FotoCek.Entities.DbClasses;
using Ninject;
using Telerik.WinControls.UI;

namespace FotoCekimi
{
    public partial class SettingForm : Form
    {
        private IKernel _kernel;
        private ICameraDal _cameraManager;
        private ITurnstileDal _turnstileManager;


        public SettingForm()
        {
            InitializeComponent();

            _kernel = new StandardKernel(new BusinessModule());
            _cameraManager = _kernel.Get<EfCameraDal>();
            _turnstileManager = _kernel.Get<EfTurnstileDal>();
        }

        private void btnTurnikeKaydet_Click(object sender, EventArgs e)
        {
            var turnstile = _turnstileManager.GetTurnstiles().Where(x => x.Name == txtTurnstileName.Text).FirstOrDefault();

            if (turnstile == null)
            {
                var result = _turnstileManager.AddTurnstile(new Turnstile()
                {
                    Name = txtTurnstileName.Text,
                    Comment = txtTurnstileComment.Text
                });

                grdTurnstiles.DataSource = _turnstileManager.GetTurnstiles();
                isRecorded(result, tabPage2);
            }
            else
            {
                MessageBox.Show("Bu isimde başka bir turnike var. Lütfen farklı bir isim girin.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void isRecorded(int result, TabPage tabPage)
        {
            if (result == 1)
            {
                foreach (var txt in tabPage.Controls)
                {
                    Type t = txt.GetType();

                    if (t.Equals(typeof(Telerik.WinControls.UI.RadTextBox)))
                    {
                        ((RadTextBox)txt).Clear();
                    }

                    drpTurnstile.Text = "";
                }

                MessageBox.Show("Kaydedildi.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKameraKaydet_Click(object sender, EventArgs e)
        {
            var turnstileId = _turnstileManager.GetTurnstileId(drpTurnstile.Text);

            var camera = _cameraManager.GetCameraByIP(txtIP.Text);

            if (camera == null)
            {
                var result = _cameraManager.AddCamera(new Camera()
                {
                    IP = txtIP.Text,
                    HTTPPort = Convert.ToInt32(txtHTTPPort.Text),
                    TCPPort = Convert.ToInt32(txtTCPPort.Text),
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    Comment = txtComment.Text,
                    IsActive = true,
                    RecordingPath = txtRecordingPath.Text,
                    CameraName = txtName.Text,
                    Location = txtLocation.Text,
                    TurnikeID = turnstileId,
                    RTSPPort = Convert.ToInt32(txtRTSPPort.Text),
                    CameraAlarmParameter = txtAlarmParameter.Text,
                    SnapshotCommand = txtSnapshotCommand.Text,

                });

                //grdCameras.DataSource = _cameraManager.GetCameras();


                grdCameras.Rows.Add(
                    txtIP.Text,
                    Convert.ToInt32(txtHTTPPort.Text),
                    Convert.ToInt32(txtTCPPort.Text),
                    txtUserName.Text,
                    txtPassword.Text,
                    txtComment.Text,
                    1,
                    txtRecordingPath.Text,
                    txtName.Text,
                    txtLocation.Text,
                    drpTurnstile.Text,
                    554,
                    txtAlarmParameter.Text,
                    txtSnapshotCommand.Text
                );


                isRecorded(result, tabPage1);
            }
            else
            {
                MessageBox.Show("Bu IP adresine sahip kamera zaten kayıtlı.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            grdCameras.DataSource = _cameraManager.GetCameras();

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            grdTurnstiles.DataSource = _turnstileManager.GetTurnstiles();
            this.Width = 500;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            this.Width = 1100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToString();
        }

        private void btnDeleteCamera_Click(object sender, EventArgs e)
        {
            var cameraIP = grdCameras.Rows[grdCameras.CurrentRow.Index].Cells["IP"].Value.ToString();
            Camera camera = _cameraManager.GetCameraByIP(cameraIP);
            _cameraManager.RemoveCamera(camera);
            grdCameras.DataSource = _cameraManager.GetCameras();

            MessageBox.Show("Kayıt Silindi.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteTurnstile_Click(object sender, EventArgs e)
        {
            var turnstileName = grdTurnstiles.Rows[grdTurnstiles.CurrentRow.Index].Cells["Name"].Value.ToString();
            Turnstile turnstile = _turnstileManager.GetTurnstile(turnstileName);

            if (turnstile != null)
            {
                var result = _turnstileManager.RemoveTurnstile(turnstile);

                grdTurnstiles.DataSource = _turnstileManager.GetTurnstiles();

                if (result == 1)
                {
                    MessageBox.Show("Kayıt Silindi.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }


        }

        private void drpTurnstile_Click(object sender, EventArgs e)
        {
            drpTurnstile.DataSource = _turnstileManager.GetTurnstiles();
            drpTurnstile.ValueMember = "Name";
            drpTurnstile.DisplayMember = "Name";
        }

        private void txtFindRecordingPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtRecordingPath.Text = fbd.SelectedPath;
            }
        }
    }
}
