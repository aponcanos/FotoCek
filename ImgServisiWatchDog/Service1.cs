using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ImgServisiWatchDog
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer tmr = new System.Timers.Timer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            tmr.Interval = 10000;
            tmr.AutoReset = true;
            tmr.Enabled = true;
            tmr.Start();
            tmr.Elapsed += Tmr_Elapsed;
        }

        protected override void OnStop()
        {
        }

        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ServiceController sc = new ServiceController("IMGServisi");

            if (!(sc.Status == ServiceControllerStatus.Running))
            {
                sc.Start();
            }

            //if ((DateTime.Now.ToString("HH") == "00") && (DateTime.Now.ToString("mm") == "00") && (DateTime.Now.ToString("ss") == "00"))
            //{
            //    sc.Stop();
            //    sc.Start();
            //}
        }
    }
}
