using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.Comman.Interfaces
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
