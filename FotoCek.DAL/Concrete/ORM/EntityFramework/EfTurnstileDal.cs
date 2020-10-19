using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete.EntityFramework;
using FotoCek.Entities.Concrete;

namespace FotoCek.DAL.Concrete.ORM.EntityFramework
{
    public class EfTurnstileDal : ITurnstileDal
    {
        public List<Turnstile> GetTurnstiles()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Turnstiles.ToList();
            }
        }

        public int AddTurnstile(Turnstile turnstile)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Turnstiles.Add(turnstile);
                return context.SaveChanges();
            }
        }

        public int RemoveTurnstile(Turnstile turnstile)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Entry(turnstile).State = EntityState.Deleted;
                context.Turnstiles.Remove(turnstile);
                return context.SaveChanges();
            }
        }

        public Turnstile GetTurnstile(string TurnstileName)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Turnstiles.Where(x => x.Name == TurnstileName).FirstOrDefault(); ;
            }
        }

        public int GetTurnstileId(string TurnstileName)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Turnstiles.Where(x => x.Name == TurnstileName).FirstOrDefault().Id; ;
            }
        }

        public string GetTurnstileName(string turnstileName)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Turnstiles.Where(x => x.Name == turnstileName).FirstOrDefault().Name; ;
            }
        }

        public string GetTurnstileName(int turnstileId)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Turnstiles.Where(x => x.Id == turnstileId).FirstOrDefault().Name; ;
            }
        }
    }
}
