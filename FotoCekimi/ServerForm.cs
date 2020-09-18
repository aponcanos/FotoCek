using FotoCek.Business;
using FotoCek.DAL;
using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FotoCek.Business.Abstract;
using FotoCek.Business.Classes.INI;
using FotoCek.Business.Concrete;
using Ini.Net;

namespace FotoCekimi
{
    public partial class ServerForm : Form
    {
        private DatabaseContext _context;
        private ITCPListener TCPListenerServer;

        public ServerForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            INIReadWrite.readWriteIniFile();
            TCPListenerServer = new SimpleTCPServerListener();

            _context = new DatabaseContext();
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            Raporlama raporlama = new Raporlama();
            raporlama.Show();
        }



        private void tmrSaat_Tick(object sender, EventArgs e)
        {
            lblTarih.Text = DateTime.Now.ToLongTimeString();

            int saat = DateTime.Now.Hour;
            int dakika = DateTime.Now.Minute;
            int saniye = DateTime.Now.Second;

            int count = (saat * 3600) + (dakika * 60) + saniye;

            int geriSayim = 86400 - count;

            if (geriSayim == 1)
            {
                lbClients.Items.Clear();
            }


            label1.Text = geriSayim.ToString();
        }

    }
}