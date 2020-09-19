
using Microsoft.Data.SqlClient;
using Res.DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// Interface for <seealso cref="Res.Infra.DataLayer.Repositories.CustomerRespository"/>
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetCustomerByName(string Name);
        /// <summary>
        /// Get Customers from DB
        /// </summary>
        /// <param name="field">Field to be use in Order By statement</param>
        /// <param name="sortDirection">ASC|DESC</param>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Number of fields to return</param>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetCustomerByPage(string field, SortOrder sortDirection, int pageIndex, int pageSize)
        ;
    }
}
