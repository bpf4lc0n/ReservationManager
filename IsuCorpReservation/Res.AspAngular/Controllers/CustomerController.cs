using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Models;
using Res.AspAngular.ViewModels;

namespace Res.AspAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerAppService;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService CustomerAppService, IMapper mapper, ILogger<CustomerController> logger)
        {
            _CustomerAppService = CustomerAppService ?? throw new ArgumentNullException(nameof(CustomerAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var list = await _CustomerAppService.GetCustomerList();
            var mapped = _mapper.Map<IEnumerable<CustomerViewModel>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        public async Task<CustomerViewModel> GetCustomersById([FromRoute] int id)
        {
            var list = await _CustomerAppService.GetCustomerById(id);
            var mapped = _mapper.Map<CustomerViewModel>(list);
            return mapped;
        }

        [HttpGet]
        [Route("api/GetCustomer/{name}")]
        public async Task<IEnumerable<CustomerViewModel>> GetCustomersByName([FromRoute] string name)
        {
            var list = await _CustomerAppService.GetCustomerByName(name);
            var mapped = _mapper.Map<IEnumerable<CustomerViewModel>>(list);
            return mapped;
        }

        [HttpPost()]
        public async Task PostCustomer(CustomerViewModel Customer)
        {
            var mapped = _mapper.Map<CustomerModel>(Customer);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _CustomerAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task PutCustomer(CustomerViewModel Customer)
        {
            var mapped = _mapper.Map<CustomerModel>(Customer);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _CustomerAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task DeleteCustomer([FromRoute] int id)
        {
            var Customer = await _CustomerAppService.GetCustomerById(id);

            var mapped = _mapper.Map<CustomerModel>(Customer);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _CustomerAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully deleted - IndexPageService");
        }
    }
}
