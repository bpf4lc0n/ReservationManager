using System.Collections.Generic;
using System.Threading.Tasks;
using Res.ApplicationLayer.Models;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReserveService
    {
        Task<IEnumerable<ReserveModel>> GetReserveList();
        Task<IEnumerable<ReserveModel>> GetReserveByPage(string field, string sortDirection, int pageIndex, int pageSize);
        Task<ReserveModel> GetReserveById(int ReserveId);
        Task<ReserveModel> Create(ReserveModel ReserveModel);
        Task Update(ReserveModel ReserveModel);
        Task Delete(ReserveModel ReserveModel);
        int GetReserveCount();
    }
}
