using System.Collections.Generic;
using System.Linq;

namespace FotoCek.DAL
{
    public partial class DatabaseManager
    {
        private DatabaseContext context;

        public DatabaseManager()
        {
            context = new DatabaseContext();
        }

        //EKLE
        public int Add<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }


        //LİSTELE
        public List<T> GetList<T>() where T:class
        {
            return context.Set<T>().AsNoTracking().ToList();
        }

        ////DELETE
        //public T DeleteList<T>() where T : class
        //{
        //    return context.Set<T>().AsNoTracking().ToList();
        //}

    }


    public partial class DatabaseManager
    {
        public int DeleteCarParkOwnerByID(int CarParkOwnerID)
        {
            string query = "delete from OwnerCarPark where ID='" + CarParkOwnerID + "'";
            context.Database.ExecuteSqlCommand(query);
            return context.SaveChanges();
        }
    }

    public partial class DatabaseManager
    {
        //public int SetWorkingType(string workingType)
        //{
            //string query = "";

            //if (context.CommonSettings.ToList().Count > 0)
            //{
            //    query = "update WorkingType set Type='" + workingType + "' where Type!='" + workingType + "'";
            //}
            //else
            //{
            //    query = "insert into WorkingType values ('" + workingType + "')";
            //}
            //return context.Database.ExecuteSqlCommand(query);
        //}
    }

}
