using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Model
{
    public class CarClassDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal PricePerDay { get; set; }
    }
}
