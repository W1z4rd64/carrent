using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Infrastructure;

namespace Carrent.CarManagment.Application
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public void Add(Car car)
        {
            _repository.Insert(car);
        }

        public void Delete(Car car)
        {
            _repository.Remove(car);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public Car GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public List<Car> GetByType(CarClass type)
        {
            return _repository.GetAll().Where(c => c.ClassId.Equals(type.Id)).ToList();
        }

        public void Update(Car car)
        {
            _repository.Update(car);
        }
    }
}
