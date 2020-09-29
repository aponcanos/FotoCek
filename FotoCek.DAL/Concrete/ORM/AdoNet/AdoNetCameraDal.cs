using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public int AddCamera(Camera camera)
        {
            using (DatabaseContext context=new DatabaseContext())
            {
                context.Cameras.Add(camera);
                return context.SaveChanges();
            }
        }

        public int RemoveCamera(Camera camera)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Cameras.Remove(camera);
                return context.SaveChanges();
            }
        }

      

        public Camera GetCamera(string cameraIpAddress)
        {
            throw new NotImplementedException();
        }
    }
}
