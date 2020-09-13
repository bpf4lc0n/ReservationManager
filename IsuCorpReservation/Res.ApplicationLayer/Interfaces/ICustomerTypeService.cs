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
    public interface ICustomerTypeService : IApplicationService
    {
        GetCustomerTypeOutput GetCustomerTypes();
    }
}
