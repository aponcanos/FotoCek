using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Entities;
using Ini.Net;


namespace FotoCek.Business.Classes.INI
{
    public static class INIReadWrite
    {
        public static void readWriteIniFile()
        {
            var iniFile = new IniFile("Configuration.ini");

            var SQLServerName = iniFile.ReadString("SQLServerConfiguration", "SQLServerName");
            var SQLServerIP = iniFile.ReadString("SQLServerConfiguration", "SQLServerIP");
            
            var DBName = iniFile.ReadString("SQLServerConfiguration", "DBName");
            var DBUserName = iniFile.ReadString("SQLServerConfiguration", "DBUserName");
            var DBPassword = iniFile.ReadString("SQLServerConfiguration", "DBPassword");

            Ayarlar.SQLServerIP = IPAddress.Parse(SQLServerIP);
            Ayarlar.SQLInstanceName =
                $"Data Source={SQLServerName};Initial Catalog={DBName} ; Integrated Security=false; User ID={DBUserName} ; Password={DBPassword}";

            var cameraUserName = iniFile.ReadString("CameraConfiguration", "CameraUserName");
            var cameraPassword = iniFile.ReadString("CameraConfiguration", "CameraPassword");
            var cameraHttpPort = Convert.ToInt32(iniFile.ReadString("CameraConfiguration", "CameraHTTPPort"));

            Ayarlar.CamUserName = cameraUserName;
            Ayarlar.CamPassword = cameraPassword;
            Ayarlar.CamHTTPPort = cameraHttpPort;

            var serverPort = Convert.ToInt32(iniFile.ReadString("ServerConfiguration", "ServerPort"));
            var serverIP = IPAddress.Parse(iniFile.ReadString("ServerConfiguration", "ServerIP"));

            Ayarlar.ServerPort = serverPort;
            Ayarlar.ServerIP = serverIP;
        }
    }
}

public class AppSettings
{
    public IPAddress ServerIP { get; set; }
}

