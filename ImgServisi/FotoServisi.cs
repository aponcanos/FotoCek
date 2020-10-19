using FotoCek.Business;
using FotoCek.DAL;
using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using FotoCek.Business.Abstract;
using FotoCek.Business.Concrete;

namespace ImgServisi
{
    public partial class FotoServisi : ServiceBase
    {
        private SimpleTCPServerListener TCPListenerServer;

        public FotoServisi()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            INIReadWrite.readWriteIniFile();

            TCPListenerServer = new SimpleTCPServerListener();
        }

        protected override void OnStop()
        {
        }
    }
}
