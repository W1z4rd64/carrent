using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Comman.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> FindById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Remove(Guid id);
        void Remove(T entity);
    }
}
