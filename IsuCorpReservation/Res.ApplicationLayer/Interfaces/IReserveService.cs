using Res.ApplicationLayer.Services;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReserveService : IApplicationService
    {
        GetReserveOutput GetReserves();
        GetReserveOutput GetReserve(GetReserveInput input);
        void UpdateReserve(UpdateReserveInput input);
        void CreateReserve(CreateReserveInput input);
        void UpdateReserveFavorietStatus(int id, bool state);
        void UpdateReserveRanking(int id, int ranking);
    }
}
