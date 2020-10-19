using System;
using System.Net;
using FotoCek.Entities;
using IniParser;
using IniParser.Model;


namespace FotoCek.Business.Concrete
{
    public static class INIReadWrite
    {
        public static void readWriteIniFile()
        {

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(@"C:\Configuration.ini");


            var SQLServerName = data["SQLServerConfiguration"]["SQLServerName"];
            var SQLServerIP = data["SQLServerConfiguration"]["SQLServerIP"];

            var DBName = data["SQLServerConfiguration"]["DBName"];
            var DBUserName = data["SQLServerConfiguration"]["DBUserName"];
            var DBPassword = data["SQLServerConfiguration"]["DBPassword"];

            Ayarlar.SQLServerIP = IPAddress.Parse(SQLServerIP);
            Ayarlar.SQLInstanceName =
                $"Data Source={SQLServerName};Initial Catalog={DBName} ; Integrated Security=false; User ID={DBUserName} ; Password={DBPassword}";


            var serverPort = Convert.ToInt32(data["ServerConfiguration"]["ServerPort"]);
            var serverIP = IPAddress.Parse(data["ServerConfiguration"]["ServerIP"]);

            Ayarlar.ServerPort = serverPort;
            Ayarlar.ServerIP = serverIP;
        }
    }
}

public class AppSettings
{
    public IPAddress ServerIP { get; set; }
}

