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
    public class ReserveService : IReserveService
    {
        private readonly IReserveRepository _iReserveRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveRepository"></param>
        public ReserveService(IReserveRepository reserveRepository)
        {
            _iReserveRepository = reserveRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReserveViewModel GetReserve()
        {
            ReserveViewModel value = new ReserveViewModel
            {
                Reserves = _iReserveRepository.GetAllReserveData()
            };
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReserveViewModel GetReserveDetails(int? id)
        {
            ReserveViewModel value = new ReserveViewModel
            {
                Reserves = _iReserveRepository.GetReserveDetails(id)
            };
            return value;
        }
    }
}
