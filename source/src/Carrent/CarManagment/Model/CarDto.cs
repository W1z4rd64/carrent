using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.CarManagment.Domain;

namespace Carrent.CarManagment.Model
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public Guid ClassId { get; set; }

        public CarClass Class { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }
    }
}
