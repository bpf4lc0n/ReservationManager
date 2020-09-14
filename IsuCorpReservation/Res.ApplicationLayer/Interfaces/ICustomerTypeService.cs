using Res.ApplicationLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerTypeService
    {
        Task<IEnumerable<CustomerTypeModel>> GetCustomerTypeList();
    }
}
