using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Mapper;
using Res.ApplicationLayer.Models;
using Res.DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Services
{
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly ICustomerTypeRepository _CustomerTypeRepository;
        private readonly IAppLogger<CustomerTypeService> _logger;

        public CustomerTypeService(ICustomerTypeRepository CustomerTypeRepository, IAppLogger<CustomerTypeService> logger)
        {
            _CustomerTypeRepository = CustomerTypeRepository ?? throw new ArgumentNullException(nameof(CustomerTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CustomerTypeModel>> GetCustomerTypeList()
        {
            var CustomerTypeList = await _CustomerTypeRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CustomerTypeModel>>(CustomerTypeList);
            return mapped;
        }
    }
}
