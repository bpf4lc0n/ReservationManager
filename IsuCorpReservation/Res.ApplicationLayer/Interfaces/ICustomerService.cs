using Abp.Application.Services;
using Res.ApplicationLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerService : IApplicationService
    {
        GetCustomerOutput GetCustomers();
        GetCustomerOutput GetCustomer(GetCustomerInput input);
        void UpdateCustomer(UpdateCustomerInput input);
        void CreateCustomer(CreateCustomerInput input);
    }
}
