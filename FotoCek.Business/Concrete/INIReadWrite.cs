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
            IniData data = parser.ReadFile("Configuration.ini");


            var SQLServerName = data["SQLServerConfiguration"]["SQLServerName"];
            var SQLServerIP = data["SQLServerConfiguration"]["SQLServerIP"];

            var DBName = data["SQLServerConfiguration"]["DBName"];
            var DBUserName = data["SQLServerConfiguration"]["DBUserName"];
            var DBPassword = data["SQLServerConfiguration"]["DBPassword"];

            Ayarlar.SQLServerIP = IPAddress.Parse(SQLServerIP);
            Ayarlar.SQLInstanceName =
                $"Data Source={SQLServerName};Initial Catalog={DBName} ; Integrated Security=false; User ID={DBUserName} ; Password={DBPassword}";


            var cameraUserName = data["CameraConfiguration"]["CameraUserName"];
            var cameraPassword = data["CameraConfiguration"]["CameraPassword"];
            var cameraHttpPort = Convert.ToInt32(data["CameraConfiguration"]["CameraHTTPPort"]);
            var cameraImageUrl = data["CameraConfiguration"]["imgUrl"];


            Ayarlar.CamUserName = cameraUserName;
            Ayarlar.CamPassword = cameraPassword;
            Ayarlar.CamHTTPPort = cameraHttpPort;
            Ayarlar.imgUrl = cameraImageUrl;

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

