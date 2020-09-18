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
        //static public string SQLInstanceName = @"Data Source=DESKTOP-MVMRPV4\SQLEXPRESS;Initial Catalog=Tozcelik_IMG ; Integrated Security=false; User ID=toscelik ; Password=toscelik";
        //static public IPAddress ServerIP = IPAddress.Parse("192.168.0.18");


        //TOSCELİK
        //static public IPAddress ServerIP = IPAddress.Parse("10.87.8.5"); //Server
        static public IPAddress ServerIP = IPAddress.Parse("10.87.28.26"); //Client
        static public string SQLInstanceName =
            @"Data Source=TSCLIMWD005\SQLEXPRESS;Initial Catalog=Tozcelik_IMG ; Integrated Security=false; User ID=toscelik ; Password=toscelik";


        static public int ServerPort = 29999;

        public static string CamUserName = "admin";
        public static string CamPassword = "admin";
        public static int CamHTTPPort= 80;



    }
}
