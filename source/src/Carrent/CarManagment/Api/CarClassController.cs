using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.CarManagment.Application;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Model;
using Microsoft.AspNetCore.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.CarManagment.Api
{
    [Route("api/carclass")]
    [ApiController]
    public class CarClassController : ControllerBase
    {
        private readonly ICarClassService _service;

        public CarClassController(ICarClassService service)
        {
            _service = service;
        }

        //GET: api/<CarClassController>
        [HttpGet]
        public List<CarClassDto> Get()
        {

            var carClass = _service.GetAll();
            return carClass.Select(x => new CarClassDto() {
                    Name = x.Name,
                    Id = x.Id,
                    PricePerDay = x.PricePerDay
            }).ToList();

        }

        // GET api/<CarClassController>/5
        [HttpGet("{id}")]
        public CarClassDto Get(Guid id)
        {
            var carClass = _service.GetById(id);
            if (carClass != null)
            {
                return new CarClassDto()
                {
                    Id = carClass.Id,
                    Name = carClass.Name,
                    PricePerDay = carClass.PricePerDay
                };
            }

            return new CarClassDto();

        }

        // POST api/<CarClassController>
        [HttpPost]
        public void Post([FromBody] CarClassDto value)
        {
            var newCarClass = new CarClass()
            {
                Id = value.Id,
                PricePerDay = value.PricePerDay,
                Name = value.Name
            };

            _service.Add(newCarClass);
        }

        // PUT api/<CarClassController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarClassDto value)
        {
            var carClass = _service.GetById(id);
            if (carClass != null)
            {
                carClass.Id = value.Id;
                carClass.Name = value.Name;
                carClass.PricePerDay = value.PricePerDay;

                _service.Add(carClass);
            }
        }

        // DELETE api/<CarClassController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var carClass = _service.GetById(id);
            if (carClass != null)
            {
                _service.DeleteById(id);
            }
        }
    }
}
