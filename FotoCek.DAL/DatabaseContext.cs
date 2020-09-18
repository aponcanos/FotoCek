using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using System.Data.Entity;

namespace FotoCek.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(Ayarlar.SQLInstanceName)
        {
        }

        public DbSet<Camera> Cameras { get; set; }
        public DbSet<MotionEvent> MotionEvents { get; set; }
        public DbSet<Log> Logs { get; set; }


    }


}
