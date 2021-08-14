using Carrent.Comman.Interfaces;
using Carrent.CarManagment.Domain;
using System.Collections.Generic;
using System;

namespace Carrent.CarManagment.Infrastructure
{
    public interface ICustomerContractRepository : IRepository<CustomerContract>
    {
        List<CustomerContract> GetByCustomerId(Guid id);
        List<CustomerContract> GetByCarId(Guid id);
    }
}
