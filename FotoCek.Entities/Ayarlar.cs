using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.Entities
{
    public static class Ayarlar
    {
        //GENET
        static public string SQLInstanceName = null;
        static public IPAddress ServerIP = IPAddress.Any;
        

        static public int ServerPort = 29999;

        public static string CamUserName = "admin";
        public static string CamPassword = "admin";
        public static int CamHTTPPort= 80;
    }
}
