using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoCek.DAL.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        int Add(T Entity);
        int Delete(T Entity);
    }
}
