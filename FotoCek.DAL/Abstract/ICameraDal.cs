using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.Entities.DbClasses;

namespace FotoCek.DAL.Abstract
{
    public interface ICameraDal
    {
        List<Camera> GetCameras();
        void AddCamera(Camera camera);
    }
}
