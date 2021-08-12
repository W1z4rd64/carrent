using System;
using System.ComponentModel.DataAnnotations;

namespace Carrent.CarManagment.Domain
{

    public class CarClass
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }
    }
}
