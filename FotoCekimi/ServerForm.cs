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
using FotoCek.Business.DependencyResolver;
using FotoCek.DAL.Concrete;
using FotoCek.DAL.Concrete.EntityFramework;
using Ini.Net;
using Ninject;
using SimpleTCP;


namespace FotoCekimi
{
    public partial class ServerForm : Form
    {
        private DatabaseContext _context;
        private ITCPListener TCPListenerServer;
        private ICameraService _cameraService;
        
      

        public ServerForm()
        {
            InitializeComponent();

            INIReadWrite.readWriteIniFile();
            TCPListenerServer = new SimpleTCPServerListener();
           
        }

        
        private void btnGetir_Click(object sender, EventArgs e)
        {
            //Raporlama raporlama = new Raporlama();
            //raporlama.Show();

        }


    }
}