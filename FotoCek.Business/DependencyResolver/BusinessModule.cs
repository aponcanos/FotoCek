 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Business.Abstract;
using FotoCek.Business.Concrete;
using Ninject.Modules;

namespace FotoCek.Business.DependencyResolver
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICameraService>().To<CameraManager>().InSingletonScope();
            Bind<IMotionEventService>().To<MotionEventManager>().InSingletonScope();
            Bind<ITakeSnapshotService>().To<TakeSnapshotManager>().InSingletonScope();
            Bind<ITurnstileService>().To<TurnstileManager>().InSingletonScope();
        }
    }
}
