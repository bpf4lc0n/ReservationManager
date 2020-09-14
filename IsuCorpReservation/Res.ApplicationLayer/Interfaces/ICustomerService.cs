﻿using Res.ApplicationLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomerList();
        Task<CustomerModel> GetCustomerById(int CustomerId);
        Task<CustomerModel> Create(CustomerModel CustomerModel);
        Task Update(CustomerModel CustomerModel);
        Task Delete(CustomerModel CustomerModel);
    }
}
