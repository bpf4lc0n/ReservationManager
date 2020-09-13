using Res.DomainLayer.Models;

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Res.Infra.DataLayer
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext() { }

        public ReservationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
