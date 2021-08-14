using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _repository = customerRepository;
        }
        public void Add(Customer customer)
        {
            _repository.Insert(customer);
        }

        public void Delete(Customer customer)
        {
            _repository.Remove(customer);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public List<Customer> GetAll()
        {
            return _repository.GetAll();
        }

        public Customer GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }
    }
}
