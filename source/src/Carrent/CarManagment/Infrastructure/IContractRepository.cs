using Carrent.Comman.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Infrastructure
{
    public interface IContractRepository : IRepository<Contract>
    {
        // zusätzliche implementierungen
    }
}
