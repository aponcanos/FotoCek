using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Entities.Concrete;

namespace FotoCek.Business.Abstract
{
    public interface ITurnstileService
    {
        List<Turnstile> GetTurnstiles();
        int RemoveTurnstile(Turnstile turnstile);
    }
}
