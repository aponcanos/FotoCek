using FotoCek.Entities;
using FotoCek.Entities.DbClasses;
using System.Data.Entity;

namespace FotoCek.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(Ayarlar.SQLInstanceName)
        {
            Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        public DbSet<Camera> Cameras { get; set; }
        public DbSet<MotionEvent> MotionEvents { get; set; }
        public DbSet<Log> Logs { get; set; }

    }

    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
        }
    }

}
