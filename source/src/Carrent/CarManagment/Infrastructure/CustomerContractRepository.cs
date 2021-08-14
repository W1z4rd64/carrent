using Carrent.CarManagment.Domain;
using Carrent.Comman.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carrent.CarManagment.Infrastructure
{
    public class CustomerContractRepository : ICustomerContractRepository
    {
        private readonly CarRentDbContext _dbContext;

        public CustomerContractRepository(CarRentDbContext carRentDbContext)
        {
            _dbContext = carRentDbContext;
        }
        public List<CustomerContract> GetAll()
        {
            return _dbContext.CustomerContracts.Select(cc => cc).ToList();
        }

        public List<CustomerContract> GetByCarId(Guid id)
        {
            return _dbContext.CustomerContracts.Select(cc => cc)
                    .Where(cc => cc.CarId.Equals(id))
                    .ToList();
        }

        public List<CustomerContract> GetByCustomerId(Guid id)
        {
            return _dbContext.CustomerContracts.Select(cc => cc)
                    .Where(cc => cc.CustomerId.Equals(id))
                    .ToList();
        }

        public CustomerContract GetById(Guid id)
        {
            return _dbContext.CustomerContracts.Select(cc => cc)
                .Where(cc => cc.Id.Equals(id))
                .FirstOrDefault();
        }

        public void Insert(CustomerContract entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var exists = GetById(id);
            if (exists != null)
            {
                _dbContext.CustomerContracts.Remove(exists);
                _dbContext.SaveChanges();
            }
        }

        public void Remove(CustomerContract entity)
        {
            Remove(entity.Id);
        }

        public void Update(CustomerContract entity)
        {
            _dbContext.CustomerContracts.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
