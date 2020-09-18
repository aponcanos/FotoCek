using System;
using System.Net.Sockets;

namespace FotoCek.Business.Classes.ReadTCP
{
    //public class ClientNode : IEquatable<string>
    //{
    //    public TcpClient tclient;
    //    public byte[] Tx, Rx;
    //    public string strId;

    //    public ClientNode()
    //    {
    //        Tx = new byte[1024];
    //        Rx = new byte[1024];
    //        strId = string.Empty;
    //        tclient = new TcpClient();
    //    }

    //    public ClientNode(TcpClient _tclient, byte[] _tx, byte[] _rx, string _str)
    //    {
    //        tclient = _tclient;
    //        Tx = _tx;
    //        Rx = _rx;
    //        strId = _str;
    //    }

    //    public ClientNode(TcpClient _tclient)
    //    {
    //        tclient = _tclient;
    //        Tx = new byte[1024];
    //        Rx = new byte[1024];
    //        strId = string.Empty;
    //    }

    //    public bool Equals(string other)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class ClientNode : IEquatable<string>
    {
        public TcpClient tclient;
        public byte[] Tx, Rx;
        public string strId;

        public ClientNode()
        {
            Tx = new byte[512];
            Rx = new byte[512];
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
            Tx = new byte[512];
            Rx = new byte[512];
            strId = string.Empty;
        }

        bool IEquatable<string>.Equals(string other)
        {
            if (string.IsNullOrEmpty(other)) return false;

            if (tclient == null) return false;

            return strId.Equals(other);
        }

        public string ToString()
        {
            return strId;
        }
    }
}

