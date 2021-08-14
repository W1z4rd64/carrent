using Carrent.CarManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.Comman.Interfaces;

namespace Carrent.CarManagment.Application
{
    public class CarClassService : ICarClassService
    {
        private readonly ICarClassRepository _reposotory;

        public CarClassService(ICarClassRepository reposotory)
        {
            _reposotory = reposotory;
        }

        public void Add(CarClass carClass)
        {
            _reposotory.Insert(carClass);
        }

        public void Delete(CarClass carClass)
        {
            _reposotory.Remove(carClass);
        }

        public void DeleteById(Guid id)
        {
            _reposotory.Remove(id);
        }

        public List<CarClass> GetAll()
        {
            return _reposotory.GetAll();
        }

        public CarClass GetById(Guid id)
        {
            return _reposotory.GetById(id);
        }

        public void Update(CarClass carClass)
        {
            _reposotory.Update(carClass);
        }
    }
}
