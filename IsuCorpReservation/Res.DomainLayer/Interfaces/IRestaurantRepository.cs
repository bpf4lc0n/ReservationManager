using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// ResturantReporsitory's Interface
    /// </summary>
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        /// <summary>
        /// Get all Restaurant, without dependencys
        /// </summary>
        /// <returns>Lis of restaurants</returns>
        IEnumerable<Restaurant> GetAllRestaurantData();
        /// <summary>
        /// Get all Restaurant, include dependency such as Reserves of the Restaurant
        /// </summary>
        /// <returns>List of restaurants</returns>
        IEnumerable<Restaurant> GetAllRestaurantFullData();
        /// <summary>
        /// Get a Restaurant by Id
        /// </summary>
        /// <param name="id">Restaurand Id</param>
        /// <returns>A singe element list</returns>
        IEnumerable<Restaurant> GetRestaurantDetails(int? id);
    }
}
