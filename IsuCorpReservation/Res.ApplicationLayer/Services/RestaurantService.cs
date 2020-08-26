using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.ViewModels;
using Res.DomainLayer.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantRepository _iRestaurantRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRestaurantRepository"></param>
        public RestaurantService(IRestaurantRepository iRestaurantRepository)
        {
            _iRestaurantRepository = iRestaurantRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RestaurantViewModel GetRestaurants()
        {
            RestaurantViewModel value = new RestaurantViewModel
            {
                Restaurants = _iRestaurantRepository.GetAllRestaurantData()
            };
            return value;
        }
    }
}
