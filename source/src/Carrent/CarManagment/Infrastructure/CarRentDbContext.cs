using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRent.Backend.Common.Infrastructure.Context;
using Carrent.CarManagment.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Carrent.Comman.Infrastructure.DbContext
{
    public class CarRentDbContext : BaseDbContext
    {
        public CarRentDbContext(DbContextOptions options) : base(options) { }

        //Add the Main Data Models
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContract> CustomerContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("CarRent_Cars");
            modelBuilder.Entity<CarClass>().ToTable("CarRent_CarClasses");
            modelBuilder.Entity<Customer>().ToTable("CarRent_Customers");
            modelBuilder.Entity<CustomerContract>().ToTable("CarRent_CustomerContracts");

            ConfigureModelBinding<Car, Guid>(modelBuilder);
            ConfigureModelBinding<CarClass, Guid>(modelBuilder);
            ConfigureModelBinding<Customer, Guid>(modelBuilder);
            ConfigureModelBinding<CustomerContract, Guid>(modelBuilder);
        }

    }
}
