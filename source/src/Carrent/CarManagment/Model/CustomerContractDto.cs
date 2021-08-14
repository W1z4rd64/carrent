using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Model
{
    public class CustomerContractDto
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime Return { get; set; }
    }
}
