using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using Res.Infra.DataLayer.Repository.Base;
using System.Threading.Tasks;
using Res.DomainLayer.Specifications;

namespace Res.Infra.DataLayer.Repositories
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(ReservationDbContext dbCtx) : base(dbCtx)
        {
        }

        public async Task<IEnumerable<Reserve>> GetReserveListAsync()
        {
            var spec = new ReserveWithCustomerAndRestaurantSpecification();
            return await GetAsync(spec);
        }
    }
}
