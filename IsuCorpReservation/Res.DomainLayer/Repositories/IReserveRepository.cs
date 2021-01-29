
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Res.DomainLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// Interface for <seealso cref="Res.Infra.DataLayer.Repositories.ReserveRespository"/>
    /// </summary>
    public interface IReserveRepository : IRepository<Reserve>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field">Field to be use in Order By statement</param>
        /// <param name="sortDirection">ASC|DESC</param>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Number of fields to return</param>
        /// <returns></returns>
        Task<IEnumerable<Reserve>> GetReserveByPage(string field, string sortDirection, int pageIndex, int pageSize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="sortDirection"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Reserve>> GetReserveByPageLinq(string field, SortOrder sortDirection, int pageIndex, int pageSize);
        /// <summary>
        /// Get the total Reserves on DB
        /// </summary>
        /// <returns>Number of Reserves</returns>
        int GetReserveCount();
    }
}
