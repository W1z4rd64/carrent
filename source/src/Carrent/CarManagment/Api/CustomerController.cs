using Carrent.CarManagment.Application;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.CarManagment.Api


{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService customerService)
        {
            _service = customerService;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public List<CustomerDto> Get()
        {
            var customer = _service.GetAll();
            return customer.Select(customer => new CustomerDto()
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Street = customer.Street,
                Housnumber = customer.Housnumber
            }).ToList();

        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDto Get(Guid id)
        {
            var customer = _service.GetById(id);
            return new CustomerDto
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Street = customer.Street,
                Housnumber = customer.Housnumber,
            };
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerDto value)
        {
            var customer = new Customer()
            {
                Id = Guid.NewGuid(),
                Firstname = value.Firstname,
                Lastname = value.Lastname,
                Street = value.Street,
                Housnumber = value.Housnumber
            };

            _service.Add(customer);

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerDto value)
        {
            var customer = new Customer()
            {
                Id = id,
                Firstname = value.Firstname,
                Lastname = value.Lastname,
                Street = value.Street,
                Housnumber = value.Housnumber
            };
            _service.Update(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _service.DeleteById(id);
        }
    }
}
