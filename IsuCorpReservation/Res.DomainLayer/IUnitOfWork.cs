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
        ICustomerRepository Customers { get; }
        /// <summary>
        /// 
        /// </summary>
        ICustomerTypeRepository CustomerType { get; }
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
