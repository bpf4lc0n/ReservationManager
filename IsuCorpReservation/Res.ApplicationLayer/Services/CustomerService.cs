
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Mapper;
using Res.ApplicationLayer.Models;
using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Res.ApplicationLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _CustomerRepository;
        private readonly IAppLogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository CustomerRepository, IAppLogger<CustomerService> logger)
        {
            _CustomerRepository = CustomerRepository ?? throw new ArgumentNullException(nameof(CustomerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerList()
        {
            var CustomerList = await _CustomerRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CustomerModel>>(CustomerList);
            return mapped;
        }

        public async Task<CustomerModel> GetCustomerById(int CustomerId)
        {
            var Customer = await _CustomerRepository.GetByIdAsync(CustomerId);
            var mapped = ObjectMapper.Mapper.Map<CustomerModel>(Customer);
            return mapped;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerByName(string Name)
        {
            var Customer = await _CustomerRepository.GetCustomerByName(Name);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CustomerModel>>(Customer);
            return mapped;
        }

        public async Task<CustomerModel> Create(CustomerModel CustomerModel)
        {
            await ValidateCustomerIfExist(CustomerModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Customer>(CustomerModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _CustomerRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<CustomerModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(CustomerModel CustomerModel)
        {
            ValidateCustomerIfNotExist(CustomerModel);

            var editCustomer = await _CustomerRepository.GetByIdAsync(CustomerModel.Id);
            if (editCustomer == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<CustomerModel, Customer>(CustomerModel, editCustomer);

            await _CustomerRepository.UpdateAsync(editCustomer);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(CustomerModel CustomerModel)
        {
            ValidateCustomerIfNotExist(CustomerModel);
            var deletedCustomer = await _CustomerRepository.GetByIdAsync(CustomerModel.Id);
            if (deletedCustomer == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _CustomerRepository.DeleteAsync(deletedCustomer);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateCustomerIfExist(CustomerModel CustomerModel)
        {
            var existingEntity = await _CustomerRepository.GetByIdAsync(CustomerModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{CustomerModel} with this id already exists");
        }

        private void ValidateCustomerIfNotExist(CustomerModel CustomerModel)
        {
            var existingEntity = _CustomerRepository.GetByIdAsync(CustomerModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{CustomerModel} with this id is not exists");
        }


        public async Task<CustomerModel> GetCustomerByPage(string sortField, SortOrder sortDirection, int pageIndex, int pageSize)
        {
            var CustomerList = await _CustomerRepository.GetCustomerByPage(sortField, sortDirection, pageIndex, pageSize);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CustomerModel>>(CustomerList);
            return (CustomerModel)mapped;
        }
    }
}
