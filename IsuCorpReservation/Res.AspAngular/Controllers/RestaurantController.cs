using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Res.ApplicationLayer.Interfaces;
using Res.AspAngular.ViewModels;

namespace Res.AspAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _RestaurantAppService;
        private readonly ILogger<RestaurantController> _logger;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService RestaurantAppService, IMapper mapper, ILogger<RestaurantController> logger)
        {
            _RestaurantAppService = RestaurantAppService ?? throw new ArgumentNullException(nameof(RestaurantAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<IEnumerable<RestaurantViewModel>> GetRestaurants()
        {
            var list = await _RestaurantAppService.GetRestaurantList();
            var mapped = _mapper.Map<IEnumerable<RestaurantViewModel>>(list);
            return mapped;
        }
    }
}
