using System;
using System.Collections.Generic;
using System.Text;
using Res.DomainLayer.Interfaces;

namespace Res.DomainLayer
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// 
        /// </summary>
        IRestaurantRepository Customers { get; }
        /// <summary>
        /// 
        /// </summary>
        ICustomerTypeRepository CustomerType { get; }
        /// <summary>
        /// 
        /// </summary>
        IRestaurantRepository Restaurants { get; }
        /// <summary>
        /// 
        /// </summary>
        IReserveRepository Reserves { get; }     

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
