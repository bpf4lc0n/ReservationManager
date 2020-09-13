using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// Interface for <seealso cref="Res.Infra.DataLayer.Repositories.CustomerRespository"/>
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAllCustomersData();
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return Null if does not exist</returns>
        IEnumerable<Customer> GetCustomersDataByName(string customerName);
    }
}
