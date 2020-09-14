using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Repository.Base;

namespace Res.Infra.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ReservationDbContext cdb) : base(cdb)
        {
        }
    }
}
