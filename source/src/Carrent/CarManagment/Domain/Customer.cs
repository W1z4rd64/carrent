using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public string Street { get; set; }

        public string Housnumber { get; set; }
    }
}
