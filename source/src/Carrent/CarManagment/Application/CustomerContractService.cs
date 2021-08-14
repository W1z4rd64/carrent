using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Application
{
    public class CustomerContractService : ICustomerContractService
    {
        private readonly ICustomerContractRepository _repository;
        public CustomerContractService(ICustomerContractRepository customerContractRepository)
        {
            _repository = customerContractRepository;
        }

        public void Add(CustomerContract item)
        {
            _repository.Insert(item);
        }

        public void Delete(CustomerContract item)
        {
            _repository.Remove(item);
        }

        public void DeleteById(Guid id)
        {
            _repository.Remove(id);
        }

        public List<CustomerContract> GetAll()
        {
            return _repository.GetAll();
        }

        public List<CustomerContract> GetByCarId(Guid id)
        {
            return _repository.GetByCustomerId(id);
        }

        public List<CustomerContract> GetByCustomerId(Guid id)
        {
            return _repository.GetByCarId(id);
        }

        public CustomerContract GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Update(CustomerContract item)
        {
            _repository.Update(item);
        }
    }
}
