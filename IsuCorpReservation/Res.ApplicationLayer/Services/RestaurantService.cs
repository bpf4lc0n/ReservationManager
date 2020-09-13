using Res.ApplicationLayer.Interfaces;
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
        private readonly IRestaurantRepository _iRestaurantRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRestaurantRepository"></param>
        public RestaurantService(IRestaurantRepository iRestaurantRepository)
        {
            _iRestaurantRepository = iRestaurantRepository;
        }       

        GetRestaurantOutput IRestaurantService.GetRestaurants()
        {
            var values = _iRestaurantRepository.GetAllRestaurantData();
            return new GetRestaurantOutput { restaurants = values };
        }
    }
}
