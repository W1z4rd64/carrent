using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Carrent.Tests.CarManagment.Infrastructure
{
    public class CarRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        public CarRepositoryTests(SharedDatabaseFixture fixture) => Fixture = fixture;

        public SharedDatabaseFixture Fixture { get; }

        [Fact]
        public void Can_add_Car()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var carClassController = new CarClassRepository(context);
                    var carController = new CarRepository(context);

                    var carCalss = carClassController.GetAll().First();
                    var newCar = new Car()
                    {
                        Id = Guid.NewGuid(),
                        Class = carCalss,
                        ClassId = carCalss.Id,
                        Brand = "VW Tiguan",
                        Type = "SUV"
                    };

                    // act
                    carController.Insert(newCar);

                    // assert
                    var dbCar = carController.GetById(newCar.Id);
                    Assert.Equal(newCar, dbCar);
                }
            }
        }

        [Fact]
        public void Can_removeById_Car()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var carController = new CarRepository(context);

                    var existsCar = carController.GetAll().First();

                    // act
                    carController.Remove(existsCar.Id);

                    // assert
                    var dbCar = carController.GetById(existsCar.Id);
                    Assert.Null(dbCar);
                }
            }
        }

        [Fact]
        public void Can_removeByObject_Car()
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    // arrange
                    var carController = new CarRepository(context);

                    var existsCar = carController.GetAll().First();

                    // act
                    carController.Remove(existsCar);

                    // assert
                    var dbCar = carController.GetById(existsCar.Id);
                    Assert.Null(dbCar);
                }
            }
        }
    }
}
