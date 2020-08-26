

using Res.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace Res.Infra.DataLayer.Context
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly ReservationDbContext _context;
      
        private readonly ILogger _logger;

        public DatabaseInitializer(ReservationDbContext context, ILogger<DatabaseInitializer> logger)
        {            
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Customers.AnyAsync())
            {
                _logger.LogInformation("Seeding initial data");

                CustomerType custT1 = new CustomerType
                {
                    ContactType = "Contact type 1"
                };

                CustomerType custT2 = new CustomerType
                {
                    ContactType = "Contact type 2"
                };

                CustomerType custT3 = new CustomerType
                {
                    ContactType = "Contact type 3"
                };

                Customer cust_1 = new Customer
                {
                    Name = "Sara",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    ContactType = custT1,
                    Telephone = "(123) 123 123"
                };

                Customer cust_2 = new Customer
                {
                    Name = "Paul",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    ContactType = custT2,
                    Telephone = "(123) 123 123"
        };

                Customer cust_3 = new Customer
                {
                    Name = "Aron",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    ContactType = custT3,
                    Telephone = "(123) 123 123"
    };

                Customer cust_4 = new Customer
                {
                    Name = "Ryan",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    ContactType = custT2,
                    Telephone = "(123) 123 123"
            };



                Restaurant rest_1 = new Restaurant
                {
                    Name = "Second Dock",
                    Description = "Second Dock",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                Restaurant rest_2 = new Restaurant
                {
                    Name = "Primer Puerto",
                    Description = "A true man's choice",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                Restaurant rest_3 = new Restaurant
                {
                    Name = "Stella",
                    Description = "Second Dock",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                Restaurant rest_4 = new Restaurant
                {
                    Name = "Islan Creek",
                    Description = "A true man's choice",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                Restaurant rest_5 = new Restaurant
                {
                    Name = "Fogo de Chao",
                    Description = "A true man's choice",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                };

                Reserve reserv_1 = new Reserve
                {
                    
                    Customer = cust_1,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Restaurant = rest_1,
                    DateReserve = new DateTime(DateTime.Now.Year, 5, 17, 21, 0, 0)
                };

                Reserve reserv_2 = new Reserve
                {
                    
                    Customer = cust_2,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Restaurant = rest_2,
                    DateReserve = new DateTime(DateTime.Now.Year, 5, 18, 20, 0, 0)
                };

                Reserve reserv_3 = new Reserve
                {
                    
                    Customer = cust_3,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Restaurant = rest_3,
                    DateReserve = new DateTime(DateTime.Now.Year, 5, 20, 19, 0, 0)
                };

                Reserve reserv_4 = new Reserve
                {
                    
                    Customer = cust_1,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Restaurant = rest_4,
                    DateReserve = new DateTime(DateTime.Now.Year, 5, 21, 20, 0, 0)
                };

                Reserve reserv_5 = new Reserve
                {
                    
                    Customer = cust_3,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Restaurant = rest_5,
                    DateReserve = new DateTime(DateTime.Now.Year, 5, 17, 21, 0, 0)
                };


                _context.Customers.Add(cust_1);
                _context.Customers.Add(cust_2);
                _context.Customers.Add(cust_3);
                _context.Customers.Add(cust_4);

                _context.Restaurants.Add(rest_1);
                _context.Restaurants.Add(rest_2);
                _context.Restaurants.Add(rest_3);
                _context.Restaurants.Add(rest_4);
                _context.Restaurants.Add(rest_5);

                _context.Reserves.Add(reserv_1);
                _context.Reserves.Add(reserv_2);
                _context.Reserves.Add(reserv_3);
                _context.Reserves.Add(reserv_4);
                _context.Reserves.Add(reserv_5);

                await _context.SaveChangesAsync();

                _logger.LogInformation("Seeding initial data completed");
            }
        }        
    }
}
