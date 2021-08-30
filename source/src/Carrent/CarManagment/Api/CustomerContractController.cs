using Carrent.CarManagment.Application;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carrent.CarManagment.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContractController : ControllerBase
    {
        private readonly ICustomerContractService _customerContractService;
        public CustomerContractController(ICustomerContractService customerContractService)
        {
            _customerContractService = customerContractService;
        }

        // GET: api/<CustomerContractController>
        [HttpGet]
        public List<CustomerContractDto> Get()
        {
            return _customerContractService.GetAll()
                .Select(cc => new CustomerContractDto()
                {
                    Id = cc.Id,
                    CarId = cc.CarId,
                    CustomerId = cc.CustomerId,
                    State = cc.State
                })
                .ToList();
        }

        // GET api/<CustomerContractController>/5
        [HttpGet("{id}")]
        public CustomerContractDto Get(Guid id)
        {
            var cusomterContract = _customerContractService.GetById(id);
            if(cusomterContract != null)
            {
                return new CustomerContractDto()
                {
                    Id = cusomterContract.Id,
                    CustomerId = cusomterContract.CustomerId,
                    CarId = cusomterContract.CarId,
                    State = cusomterContract.State,
                    PickUp = cusomterContract.PickUp,
                    Return = cusomterContract.Return
                };
            }

            return new CustomerContractDto();
        }

        // POST api/<CustomerContractController>
        [HttpPost]
        public void Post([FromBody] CustomerContractDto value)
        {
            var costmerContract = new CustomerContract()
            {
                Id = Guid.NewGuid(),
                CustomerId = value.CustomerId,
                CarId = value.CarId,
                State = value.State,
                PickUp = value.PickUp,
                Return = value.Return
            };

            _customerContractService.Add(costmerContract);
        }

        // PUT api/<CustomerContractController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CustomerContractDto value)
        {
            var costmerContract = new CustomerContract()
            {
                Id = id,
                CustomerId = value.CustomerId,
                CarId = value.CarId,
                State = value.State,
                PickUp = value.PickUp,
                Return = value.Return
            };

            _customerContractService.Update(costmerContract);
        }

        // DELETE api/<CustomerContractController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _customerContractService.DeleteById(id);
        }

        // GET api/<CustomerContractController>/5
        [HttpGet("{GetByCustomerId/id}")]
        public List<CustomerContractDto> GetByCustomerId(Guid id)
        {
            return _customerContractService.GetByCustomerId(id)
                .Select(cc => new CustomerContractDto()
                {
                    Id = cc.Id,
                    CustomerId = cc.CustomerId,
                    CarId = cc.CarId,
                    State = cc.State
                })
                .ToList();
        }
    }
}
