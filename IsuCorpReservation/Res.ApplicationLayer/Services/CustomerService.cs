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
    public class CustomerService : ICustomerService
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CustomerViewModel GetCustomers()
        {
            CustomerViewModel value = new CustomerViewModel
            {
                Customers = _iCustomerRepository.GetAllCustomersData()
            };
            return value;
        }
    }
}
