using Res.DomainLayer.Models;
using System.Collections.Generic;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// Interface for <seealso cref="Res.Infra.DataLayer.Repositories.ReserveRespository"/>
    /// </summary>
    public interface IReserveRepository
    {
        /// <summary>
        /// Get all Restaurant, include dependencys
        /// </summary>
        /// <returns></returns>
        IEnumerable<Reserve> GetAllReserveData();
        /// <summary>
        /// Get all Reserve, include dependency such as Restaurant and Customer
        /// </summary>
        /// <param name="id">Id of the Reserve to search</param>
        /// <returns></returns>
        IEnumerable<Reserve> GetReserveDetails(int? id);
    }
}
