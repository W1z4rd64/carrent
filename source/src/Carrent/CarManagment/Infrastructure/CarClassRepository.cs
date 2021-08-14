using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.CarManagment.Domain;
using Carrent.Comman.Infrastructure.DbContext;
using Carrent.Comman.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carrent.CarManagment.Infrastructure
{
    public class CarClassRepository : ICarClassRepository
    {
        private readonly CarRentDbContext _dbContext;
        public CarClassRepository(CarRentDbContext carRentDbContext)
        {
            _dbContext = carRentDbContext;
        }
        public CarClass GetById(Guid id)
        {
            return _dbContext.CarClasses.Select(cc => cc).Where(cc => cc.Id.Equals(id)).FirstOrDefault();
        }

        public List<CarClass> GetAll()
        {
            return _dbContext.CarClasses.Select(cc => cc).ToList();
        }

        public void Insert(CarClass entity)
        {
            _dbContext.Add(entity);
            Update(entity);
        }

        public void Remove(Guid id)
        {
            var exists = GetById(id);
            if (exists != null)
            {
                _dbContext.CarClasses.Remove(exists);
                _dbContext.SaveChanges();
            }
        }

        public void Remove(CarClass entity)
        {
            Remove(entity.Id);
        }

        public void Update(CarClass entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
