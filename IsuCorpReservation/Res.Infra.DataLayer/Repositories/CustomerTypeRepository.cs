using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.Infra.DataLayer.Repositories
{
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(ReservationDbContext cdb) : base(cdb)
        {
        }
    }
}
