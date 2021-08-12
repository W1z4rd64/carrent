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
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Add(Customer car)
        {
            _customerRepository.Insert(car);
        }

        public void Delete(Customer car)
        {
            _customerRepository.Remove(car);
        }

        public void DeleteById(Guid id)
        {
            _customerRepository.Remove(id);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(Guid id)
        {
            return _customerRepository.FindById(id).FirstOrDefault();
        }

        public void Update(Customer car)
        {
            _customerRepository.Update(car);
        }
    }
}
