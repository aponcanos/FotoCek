using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.Client.Classes
{
    public class ClientNode : IEquatable<string>
    {
        public TcpClient tclient;
        public byte[] Tx, Rx;
        public string strId;

        public ClientNode()
        {
            Tx = new byte[1024];
            Rx = new byte[1024];
            strId = string.Empty;
            tclient = new TcpClient();
        }

        public ClientNode(TcpClient _tclient, byte[] _tx, byte[] _rx, string _str)
        {
            tclient = _tclient;
            Tx = _tx;
            Rx = _rx;
            strId = _str;
        }

        public ClientNode(TcpClient _tclient)
        {
            tclient = _tclient;
            Tx = new byte[1024];
            Rx = new byte[1024];
            strId = string.Empty;
        }

        public bool Equals(string other)
        {
            throw new NotImplementedException();
        }
    }
}
