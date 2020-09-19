using Microsoft.Data.SqlClient;
using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Customer>> GetCustomerByName(string Name)
        {
            Name = string.IsNullOrEmpty(Name) ? string.Empty : Name.TrimEnd().TrimStart();
            Expression<Func<Customer, bool>> predicate = person => person.Name.Equals(Name);
            return await GetAsync(predicate);
        }

        /// <summary>
        /// In order to do Server Side pagination
        /// </summary>
        /// <param name="field">Field for sorting</param>
        /// <param name="sortDirection"></param>
        /// <param name="pageIndex">Start at 1</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetCustomerByPage(string field, SortOrder sortDirection, int pageIndex, int pageSize)
        {
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy;


            if (sortDirection == SortOrder.Ascending)
                orderBy = value => value.OrderBy(d => d.Name);
            else
                orderBy = value => value.OrderByDescending(d => d.Name);


            return await GetPageAsync(null, orderBy, pageIndex, pageSize, true);
        }
    }
}
