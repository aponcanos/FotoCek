using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete.EntityFramework;
using FotoCek.Entities.DbClasses;

namespace FotoCek.DAL.Concrete
{
    public class EfCameraDal: ICameraDal
    {
        public List<Camera> GetCameras()
        {
            using (DatabaseContext context=new DatabaseContext())
            {
                return context.Cameras.ToList();
            }
        }

        public int AddCamera(Camera camera)
        {
            using (DatabaseContext context =new DatabaseContext())
            {
                context.Cameras.Add(camera);
                return context.SaveChanges();
            }
        }

        public int RemoveCamera(Camera camera)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Entry(camera).State = EntityState.Deleted;
                context.Cameras.Remove(camera);
                return context.SaveChanges();
            }
        }

        public Camera GetCameraByIP(string cameraIpAddress)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Cameras.Where(x => x.IP == cameraIpAddress).FirstOrDefault();
            }
        }

    }
}
