using FotoCek.DAL.Abstract;
using FotoCek.DAL.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using FotoCek.Entities.Abstract;

namespace FotoCek.DAL.Concrete.ORM.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    {
        public int Add(TEntity Entity)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                //context.MotionEvents.Add(Entity);
               return context.SaveChanges();
            }
        }

        public int Delete(TEntity Entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
