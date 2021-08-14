using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Carrent.CarManagment.Domain;
using CarRent.Backend.Common.Infrastructure.Context;
using Carrent.Comman.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Carrent.CarManagment.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentDbContext _dbContext;
        public CarRepository(CarRentDbContext carRentDbContext)
        {
            _dbContext = carRentDbContext;
        }

        public Car GetById(Guid id)
        {
            return _dbContext.Cars.Include(x => x.Class).Where(car => car.Id.Equals(id)).FirstOrDefault();
        }

        public List<Car> GetAll()
        {
            return _dbContext.Cars.Select(x => x).Include(x => x.Class).ToList();
        }

        public void Insert(Car entity)
        {
            _dbContext.Cars.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var exists = GetById(id);
            if (exists != null)
            {
                _dbContext.Cars.Remove(exists);
                _dbContext.SaveChanges();
            }
        }

        public void Remove(Car entity)
        {
            Remove(entity.Id);
        }

        public void Update(Car entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
