using Res.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

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

    }
}
