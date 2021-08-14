using Carrent.CarManagment.Application;
using Carrent.CarManagment.Domain;
using Carrent.Comman.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarRentDbContext _dbContext;

        public CustomerRepository(CarRentDbContext carRentDbContext)
        {
            _dbContext = carRentDbContext;
        }
        public Customer GetById(Guid id)
        {
            return _dbContext.Customers.Select(c => c).Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Customers.Select(c => c).ToList();
        }

        public void Insert(Customer entity)
        {
            _dbContext.Customers.Add(entity);
            Update(entity);
        }

        public void Remove(Guid id)
        {
            var customer = GetById(id);
            if(customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public void Remove(Customer entity)
        {
            Remove(entity.Id);
        }

        public void Update(Customer entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
