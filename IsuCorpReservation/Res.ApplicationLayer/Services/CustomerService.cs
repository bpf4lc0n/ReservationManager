using Abp.Application.Services;
using Res.ApplicationLayer.Interfaces;
using Res.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerService : ApplicationService, ICustomerService
    {
        private readonly ICustomerRepository _iCustomerRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iCustomerRepository"></param>
        public CustomerService(ICustomerRepository iCustomerRepository)
        {
            _iCustomerRepository = iCustomerRepository;
        }

        public void CreateCustomer(CreateCustomerInput input)
        {
            throw new NotImplementedException();
        }

        public GetCustomerOutput GetCustomer(GetCustomerInput input)
        {
            throw new NotImplementedException();
        }

        public GetCustomerOutput GetCustomers()
        {
            var values = _iCustomerRepository.GetAllCustomersData();
            return new GetCustomerOutput() { customers = values };
        }

        public void UpdateCustomer(UpdateCustomerInput input)
        {
            throw new NotImplementedException();
        }
    }
}
