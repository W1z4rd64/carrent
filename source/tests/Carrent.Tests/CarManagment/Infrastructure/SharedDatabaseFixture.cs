using Carrent.CarManagment.Domain;
using Carrent.Comman.Infrastructure.DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Carrent.Tests.CarManagment.Infrastructure
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        public SharedDatabaseFixture()
        {
            Connection = new SqlConnection(@"Data Source=.; Database=CarRent_XUnit_Tests; Trusted_Connection=True");

            Seed();

            Connection.Open();
        }

        public DbConnection Connection { get; }

        public CarRentDbContext CreateContext(DbTransaction transaction = null)
        {
            var context = new CarRentDbContext(new DbContextOptionsBuilder<CarRentDbContext>().UseSqlServer(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        var carClass = new CarClass()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Standard",
                            PricePerDay = 100
                        };
                        context.CarClasses.Add(carClass);
                        context.SaveChanges();

                        var car = new Car()
                        {
                            Id = Guid.NewGuid(),
                            ClassId = carClass.Id,
                            Class = carClass,
                            Brand = "Audi A3",
                            Type = "Limousine"
                        };
                        context.Cars.Add(car);
                        context.SaveChanges();


                        var customer = new Customer()
                        {
                            Id = Guid.NewGuid(),
                            Firstname = "Marc",
                            Lastname = "Peters",
                            Housnumber = "78",
                            Street = "Wecken"
                        };
                        context.Customers.Add(customer);
                        context.SaveChanges();




                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose() => Connection.Dispose();
    }
}