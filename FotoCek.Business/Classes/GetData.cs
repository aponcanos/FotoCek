using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.Business.Classes
{
    public class GetData
    {
        TcpClient tcpClient2;
        Byte[] data;
        NetworkStream stream2;
        Socket s;


        public void GetDataFromServer(TcpClient tcpClient, string GetirilecekResimBilgisi)
        {
            //tcpClient2 = new TcpClient("192.168.0.34", 29999);

            data = Encoding.ASCII.GetBytes(GetirilecekResimBilgisi);
            stream2 = tcpClient.GetStream();
            stream2.Write(data, 0, data.Length);
            s = tcpClient.Client;
            //tcpClient2.Close();
        }
    }
}
