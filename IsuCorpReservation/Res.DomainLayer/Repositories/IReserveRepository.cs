
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
        Task<IEnumerable<Reserve>> GetReserveByPage(string field, string sortDirection, int pageIndex, int pageSize);

        int GetReserveCount();
    }
}
