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
        private SimpleTCPServerListener TCPListenerServer;

        public ServerForm()
        {
            InitializeComponent();

            INIReadWrite.readWriteIniFile();
            TCPListenerServer = new SimpleTCPServerListener();
           
            TCPListenerServer.ClientConnected += ServerForm_ClientConnected;
            TCPListenerServer.DataReceived += ServerForm_DataReceived;
        }

        private void ServerForm_DataReceived(object sender, SimpleTCP.Message e)
        {
            MessageBox.Show("Test");
        }

        private void ServerForm_ClientConnected(object sender, TcpClient e)
        {
            MessageBox.Show("Test");
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            //Raporlama raporlama = new Raporlama();
            //raporlama.Show();

        }


    }

  
}