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
        private readonly CarRentDbContext _carRentDbContext;
        public CarClassRepository(CarRentDbContext carRentDbContext)
        {
            _carRentDbContext = carRentDbContext;
        }
        public List<CarClass> FindById(Guid id)
        {
            return _carRentDbContext.CarClasses.Select(cc => cc).Where(cc => cc.Id.Equals(id)).ToList();
        }

        public List<CarClass> GetAll()
        {
            return _carRentDbContext.CarClasses.Select(cc => cc).ToList();
        }

        public void Insert(CarClass entity)
        {
            _carRentDbContext.Add(entity);
            Update(entity);
        }

        public void Remove(Guid id)
        {
            var exists = FindById(id).First();
            if (exists != null)
            {
                _carRentDbContext.CarClasses.Remove(exists);
                Update(exists);
            }
        }

        public void Remove(CarClass entity)
        {
            Remove(entity.Id);
        }

        public void Update(CarClass entity)
        {
            //_carRentDbContext.Update(entity);
            _carRentDbContext.SaveChanges();
        }
    }
}
