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
    public class CustomerRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        public CustomerRepositoryTests(SharedDatabaseFixture fixture) => Fixture = fixture;

        public SharedDatabaseFixture Fixture { get; }

        [Fact]
        public void Can_add_Customer()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var customerController = new CustomerRepository(context);

                    var newCustomer = new Customer()
                    {
                        Id = Guid.NewGuid(),
                        Firstname = "Hans",
                        Lastname = "Peter",
                        Street = "Wartstrasse",
                        Housnumber = "7a"
                    };

                    // act
                    customerController.Insert(newCustomer);

                    // assert
                    var dbCustomer = customerController.GetById(newCustomer.Id);
                    Assert.Equal(newCustomer, dbCustomer);
                }
            }
        }

        [Fact]
        public void Can_removeById_Customer()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var customerController = new CustomerRepository(context);

                    var existsCustomer = customerController.GetAll().First();

                    // act
                    customerController.Remove(existsCustomer.Id);

                    // assert
                    var dbCrustomer = customerController.GetById(existsCustomer.Id);
                    Assert.Null(dbCrustomer);
                }
            }
        }

        [Fact]
        public void Can_removeByObject_Customer()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var cusotmerController = new CarRepository(context);

                    var existsCusotmer = cusotmerController.GetAll().First();

                    // act
                    cusotmerController.Remove(existsCusotmer);

                    // assert
                    var dbCustomer= cusotmerController.GetById(existsCusotmer.Id);
                    Assert.Null(dbCustomer);
                }
            }
        }
    }
}
