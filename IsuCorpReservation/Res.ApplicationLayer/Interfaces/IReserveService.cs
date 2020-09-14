using Res.ApplicationLayer.Services;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
        Task<ReserveModel> GetReserveById(int ReserveId);
        Task<ReserveModel> Create(ReserveModel ReserveModel);
        Task Update(ReserveModel ReserveModel);
        Task Delete(ReserveModel ReserveModel);
    }
}
