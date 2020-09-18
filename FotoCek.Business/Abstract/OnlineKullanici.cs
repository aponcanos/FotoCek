using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.Business
{
    public static class onlineKullanici
    {
        static string _onlineKullaniciAdi;

        public static string OnlineKullaniciAdi { get => _onlineKullaniciAdi; set => _onlineKullaniciAdi = value; }
    }
}
