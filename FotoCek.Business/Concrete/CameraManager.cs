using FotoCek.Business.Abstract;
using FotoCek.DAL.Abstract;
using FotoCek.Entities.DbClasses;
using System.Collections.Generic;

namespace FotoCek.Business.Concrete
{
    public class CameraManager:ICameraService
    {
        private ICameraDal _cameraDal;

        public CameraManager(ICameraDal cameraDal)
        {
            _cameraDal = cameraDal;
        }

        public List<Camera> GetCameras()
        {
            return _cameraDal.GetCameras();
        }
    }
}
