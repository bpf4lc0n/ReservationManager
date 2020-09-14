using Abp.Application.Services;
using Res.ApplicationLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantModel>> GetRestaurantList();
    }
}
