using Carrent.CarManagment.Domain;
using Carrent.Comman.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Infrastructure
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        // Customer Add
    }
}
