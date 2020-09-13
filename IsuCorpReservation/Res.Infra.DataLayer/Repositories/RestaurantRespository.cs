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
        private readonly ReservationDbContext _context;
        public RestaurantRespository(ReservationDbContext dbCtx)
        {          
             _context = dbCtx;  
        }

        public void Add(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Restaurant> entities)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> Find(Expression<Func<Restaurant, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
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

        public Restaurant GetSingleOrDefault(Expression<Func<Restaurant, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Restaurant> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Restaurant> entities)
        {
            throw new NotImplementedException();
        }
    }
}
