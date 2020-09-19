
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
        Task<IEnumerable<Customer>> GetCustomerByName(string Name);
        Task<IEnumerable<Customer>> GetCustomerByPage(string field, SortOrder sortDirection, int pageIndex, int pageSize)
        ;
    }
}
