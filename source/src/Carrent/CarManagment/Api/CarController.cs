using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.CarManagment.Application;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.Api
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ICarClassService _carClassService;

        public CarController(ICarService carService, ICarClassService carClassService)
        {
            _carService = carService;
            _carClassService = carClassService;
        }


        // GET: api/<CarController>
        [HttpGet]
        public List<CarDto> Get()
        {
            var car = _carService.GetAll();
            // Mapping Car-Object to CarDto-Object
            return car.Select(car => new CarDto()
            {
                Brand = car.Brand,
                //Class = car.Class,
                ClassId = car.ClassId,
                Id = car.Id
            }).ToList();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarDto Get(Guid id)
        {
            var car = _carService.GetById(id);
            // Mapping Car-Object to CarDto-Object
            return new CarDto()
            {
                //Class = car.Class,
                Brand = car.Brand,
                ClassId = car.ClassId,
                Id = car.Id
            };
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] CarDto value)
        {
            var newCar = new Car()
            {
                Id = Guid.NewGuid(),
                ClassId = value.ClassId,
                Brand = value.Brand,
                Type = value.Type,
            };

            newCar.Class = _carClassService.GetById(value.ClassId);
            _carService.Add(newCar);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarDto value)
        {


            var car =_carService.GetById(id);
            if (car != null)
            {
                car.Brand = value.Brand;
                car.ClassId = id;
                car.Type = car.Type;
                _carService.Update(car);
            }
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _carService.DeleteById(id);
        }
    }
}
