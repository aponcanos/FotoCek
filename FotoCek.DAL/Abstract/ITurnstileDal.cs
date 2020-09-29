using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Entities.Concrete;
using FotoCek.Entities.DbClasses;

namespace FotoCek.DAL.Abstract
{
    public interface ITurnstileDal
    {
        List<Turnstile> GetTurnstiles();
        int AddTurnstile(Turnstile turnstile);
        int RemoveTurnstile(Turnstile turnstile);

        Turnstile GetTurnstile(string TurnstileName);
    }
}
