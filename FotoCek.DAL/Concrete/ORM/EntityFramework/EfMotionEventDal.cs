using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.DAL.Abstract;
using FotoCek.Entities.DbClasses;

namespace FotoCek.DAL.Concrete.EntityFramework
{
    public class EfMotionEventDal:IMotionEventDal
    {
        public List<MotionEvent> GetMotionEvents()
        {
            using (DatabaseContext context=new DatabaseContext())
            {
                return context.MotionEvents.ToList();
            }
        }

        public void AddMotionEvent(MotionEvent motionEvent)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.MotionEvents.Add(motionEvent);
                context.SaveChanges();
            }
        }

    }
}
