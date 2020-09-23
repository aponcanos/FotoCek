using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Business.Abstract;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete.EntityFramework;
using FotoCek.Entities.DbClasses;

namespace FotoCek.Business.Concrete
{
    public class MotionEventManager:IMotionEventService
    {
        private IMotionEventDal _motionEvent;

        public MotionEventManager(IMotionEventDal motionEvent)
        {
            _motionEvent = motionEvent;
        }


        public List<MotionEvent> GetMotionEvents()
        {
           return _motionEvent.GetMotionEvents();
        }

        public void AddMotionEvent(MotionEvent motionEvent)
        {
            _motionEvent.AddMotionEvent(motionEvent);
        }
    }
}
