using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Res.Infra.DataLayer.Repositories
{
    public class RestaurantRespository : IRestaurantRepository
    {
        private ReservationDbContext _context;
        public RestaurantRespository(ReservationDbContext dbCtx)
        {          
             _context = dbCtx;  
        }

        /// <summary>
        /// Get all Restaurant, without dependencys
        /// </summary>
        /// <returns>Lis of restaurants</returns>
        public IEnumerable<Restaurant> GetAllRestaurantData()
        {
            try
            {
                return _context.Restaurants;
            }
            catch
            {
                return new List<Restaurant>();
            }
        }
        /// <summary>
        /// Get all Restaurant, include dependency such as Reserves of the Restaurant
        /// </summary>
        /// <returns>List of restaurants</returns>
        public IEnumerable<Restaurant> GetAllRestaurantFullData()
        {
            try
            {
                return _context.Restaurants;
            }
            catch
            {
                return new List<Restaurant>();
            }
        }
        /// <summary>
        /// Get a Restaurant by Id
        /// </summary>
        /// <param name="id">Restaurand Id</param>
        /// <returns>A singe element list</returns>
        public IEnumerable<Restaurant> GetRestaurantDetails(int? id)
        {
            var restaurant = _context.Restaurants
                .Where(vl => vl.Id == id).ToList();

            if (restaurant == null)
            {
                return null;
            }

            return restaurant;
        }
    }
}
