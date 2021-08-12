using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Application
{
    public interface IService<T>
    {
        List<T> GetAll();

        T GetById(Guid id);

        void Add(T car);

        void DeleteById(Guid id);

        void Delete(T car);

        void Update(T car);
    }
}
