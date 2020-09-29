using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Business.Abstract;
using FotoCek.DAL.Abstract;
using FotoCek.Entities.Concrete;

namespace FotoCek.Business.Concrete
{
    public class TurnstileManager : ITurnstileService
    {
        private ITurnstileDal _turnstileDal;
        public TurnstileManager(ITurnstileDal turnstileDal)
        {
            _turnstileDal = turnstileDal;
        }

        public List<Turnstile> GetTurnstiles()
        {
            return _turnstileDal.GetTurnstiles();
        }

        public int RemoveTurnstile(Turnstile turnstile)
        {
            return _turnstileDal.RemoveTurnstile(turnstile);
        }
    }
}
