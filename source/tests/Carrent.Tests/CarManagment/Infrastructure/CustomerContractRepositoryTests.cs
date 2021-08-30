using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Infrastructure;
using Xunit;

namespace Carrent.Tests.CarManagment.Infrastructure
{
    public class CustomerContractRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {

        public CustomerContractRepositoryTests(SharedDatabaseFixture fixture) => Fixture = fixture;

        public SharedDatabaseFixture Fixture { get; }

        [Fact]
        public void Can_add_CustomerContract()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var customerController = new CustomerRepository(context);
                    var customerDb = customerController.GetAll().FirstOrDefault();
                    var carController = new CarRepository(context);
                    var carDb = carController.GetAll().FirstOrDefault();

                    var customerContractController = new CustomerContractRepository(context);

                    var newCustomerContrect = new CustomerContract()
                    {
                        Id = Guid.NewGuid(),
                        CarId = carDb.Id,
                        CustomerId = customerDb.Id,
                        PickUp = new DateTime(2000,1,1,12,0,0),
                        Return = new DateTime(2000, 1, 2, 12, 0, 0),
                        State = "Reservation"
                    };

                    // act
                    customerContractController.Insert(newCustomerContrect);

                    // assert
                    var customerContractDb = customerContractController.GetById(newCustomerContrect.Id);
                    Assert.Equal(newCustomerContrect, customerContractDb);
                }
            }
        }

        [Fact]
        public void Can_removeById_CustomerContract()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var customerContractController = new CustomerContractRepository(context);

                    var existsCusotmerContract = customerContractController.GetAll().First();

                    // act
                    customerContractController.Remove(existsCusotmerContract.Id);

                    // assert
                    var customerContractDb = customerContractController.GetById(existsCusotmerContract.Id);
                    Assert.Null(customerContractDb);
                }
            }
        }

        [Fact]
        public void Can_removeByObject_CustomerContract()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var customerContractController = new CustomerContractRepository(context);

                    var existsCar = customerContractController.GetAll().First();

                    // act
                    customerContractController.Remove(existsCar);

                    // assert
                    var customerContractDb = customerContractController.GetById(existsCar.Id);
                    Assert.Null(customerContractDb);
                }
            }
        }
    }
}
