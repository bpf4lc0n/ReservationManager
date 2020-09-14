using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Mapper;
using Res.ApplicationLayer.Models;
using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _RestaurantRepository;
        private readonly IAppLogger<RestaurantService> _logger;

        public RestaurantService(IRestaurantRepository RestaurantRepository, IAppLogger<RestaurantService> logger)
        {
            _RestaurantRepository = RestaurantRepository ?? throw new ArgumentNullException(nameof(RestaurantRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<RestaurantModel>> GetRestaurantList()
        {
            var RestaurantList = await _RestaurantRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<RestaurantModel>>(RestaurantList);
            return mapped;
        }
    }
}
