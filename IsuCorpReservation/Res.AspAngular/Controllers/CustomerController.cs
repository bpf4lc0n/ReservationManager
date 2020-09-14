using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Res.ApplicationLayer.Interfaces;
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
    }
}
