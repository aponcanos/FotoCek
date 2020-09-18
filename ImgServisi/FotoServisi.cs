using FotoCek.Business;
using FotoCek.Business.Classes.ReadTCP;
using FotoCek.DAL;
using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.ServiceProcess;

namespace ImgServisi
{
    public partial class FotoServisi : ServiceBase
    {
        CheckAlarmStatusOnTCP _readTcp;
        private List<Camera> _lstAllCameras;
        private DatabaseContext _context;

        public FotoServisi()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            
        }

        protected override void OnStop()
        {
        }
    }
}
