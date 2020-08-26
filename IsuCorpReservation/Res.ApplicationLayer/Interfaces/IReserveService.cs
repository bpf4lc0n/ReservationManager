using Res.ApplicationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReserveService
    {
        ReserveViewModel GetReserve();
        ReserveViewModel GetReserveDetails(int? id);
    }
}
