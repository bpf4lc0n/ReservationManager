using Res.DomainLayer.Models;
using System.Collections.Generic;

namespace Res.ApplicationLayer.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class RestaurantViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
