using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Reserve>> GetCustomerByName(string Name)
        {
            Name = string.IsNullOrEmpty(Name) ? string.Empty : Name.TrimEnd().TrimStart();
            Expression<Func<Customer, bool>> predicate = person => person.Name.Equals(Name);
            return (IEnumerable<Reserve>)await GetAsync(predicate);
        }
    }
}
