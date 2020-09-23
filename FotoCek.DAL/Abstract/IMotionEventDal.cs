using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Entities.DbClasses;

namespace FotoCek.DAL.Abstract
{
    public interface IMotionEventDal
    {
         List<MotionEvent> GetMotionEvents();
         void AddMotionEvent(MotionEvent motionEvent);
    }
}
