using Res.DomainLayer.Models;
using System.Collections.Generic;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// Interface for <seealso cref="Res.Infra.DataLayer.Repositories.ReserveRespository"/>
    /// </summary>
    public interface IReserveRepository : IRepository<Reserve>
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
        /// <summary>
        /// Add a new value of Reserve
        /// </summary>
        /// <param name="reserve">Reserve value to be added</param>
        /// <returns></returns>
        int PostReserve(Reserve reserve);
    }
}
