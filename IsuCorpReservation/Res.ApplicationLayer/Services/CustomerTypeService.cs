using Res.ApplicationLayer.Interfaces;
using Res.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    class CustomerTypeService : ICustomerTypeService
    {
        private readonly ICustomerTypeRepository _iCustomerTypeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCustomerTypeRepository"></param>
        public CustomerTypeService(ICustomerTypeRepository iCustomerTypeRepository)
        {
            _iCustomerTypeRepository = iCustomerTypeRepository;
        }

        GetCustomerTypeOutput ICustomerTypeService.GetCustomerTypes()
        {
            var values = _iCustomerTypeRepository.GetAllCustomerTypeData();
            return new GetCustomerTypeOutput { customerTypes = values };
        }
    }
}
