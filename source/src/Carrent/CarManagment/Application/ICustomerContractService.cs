using Carrent.CarManagment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Application
{
    public interface ICustomerContractService : IService<CustomerContract>
    {
        List<CustomerContract> GetByCustomerId(Guid id);
        List<CustomerContract> GetByCarId(Guid id);
    }
}
