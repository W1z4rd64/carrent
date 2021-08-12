using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Carrent.CarManagment.Domain;
using Carrent.Comman.Interfaces;
using CarRent.Backend.Common.Infrastructure.Context;
using Carrent.Comman.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Carrent.CarManagment.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentDbContext _carRentDbContext;
        public CarRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }

        public List<Car> FindById(Guid id)
        {
            return _carRentDbContext.Cars.Include(x => x.Class).Where(car => car.Id.Equals(id)).ToList();
        }

        public List<Car> GetAll()
        {
            return _carRentDbContext.Cars.Include(x => x.Class).ToList();
        }

        public void Insert(Car entity)
        {
            _carRentDbContext.Cars.Add(entity);
            Update(entity);
        }

        public void Remove(Guid id)
        {
            var exists = FindById(id).First();
            if (exists != null)
            {
                _carRentDbContext.Cars.Remove(exists);
                Update(exists);
            }
        }

        public void Remove(Car entity)
        {
            Remove(entity.Id);
        }

        public void Update(Car entity)
        {
            _carRentDbContext.SaveChanges();
            //var exists = FindById(entity.Id);
            //if (exists != null)
            //{
            //    _carRentDbContext.Cars.Update(entity);
            //}
        }
    }
}
