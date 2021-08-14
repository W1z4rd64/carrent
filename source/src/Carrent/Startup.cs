using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carrent.CarManagment.Application;
using Carrent.CarManagment.Domain;
using Carrent.CarManagment.Infrastructure;
using Carrent.Comman.Infrastructure.DbContext;
using Carrent.Comman.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carrent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //add the database context
            services.AddDbContext<CarRentDbContext>(config =>
            {
                // Konfiguration zum Connection String in appsettings.json
                config.UseSqlServer(Configuration.GetConnectionString("baseConnection"));
            });


            services.AddTransient<ICarService, CarService>();
            services.AddScoped<ICarRepository, CarRepository>();

            services.AddTransient<ICarClassService, CarClassService>();
            services.AddScoped<ICarClassRepository, CarClassRepository>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddTransient<ICustomerContractService, CustomerContractService>();
            services.AddScoped<ICustomerContractRepository, CustomerContractRepository>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Carrent", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carrent v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
