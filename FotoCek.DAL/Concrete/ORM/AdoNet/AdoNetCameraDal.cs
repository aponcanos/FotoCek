using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete.EntityFramework;
using FotoCek.Entities.DbClasses;

namespace FotoCek.DAL.Concrete.AdoNet
{
    class AdoNetCameraDal:ICameraDal
    {
        public List<Camera> GetCameras()
        {
            throw new NotImplementedException();
        }

        public void AddCamera(Camera camera)
        {
            using (DatabaseContext context=new DatabaseContext())
            {
                context.Cameras.Add(camera);
                context.SaveChanges();
            }
        }
    }
}
