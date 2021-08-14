using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment.Domain
{
    public class CustomerContract
    {

        public enum States
        {
            Reservation,
            Booked,
            OpenAccount,
            ClosedAccount
        }

        public Guid Id { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public Guid CarId { get; set; }

        [Required]
        public DateTime PickUp { get; set; }

        [Required]
        public DateTime Return { get; set; }
    }
}
