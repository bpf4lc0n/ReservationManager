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
    public class CustomerTypeController : ControllerBase
    {
        private readonly ICustomerTypeService _CustomerTypeAppService;
        private readonly ILogger<CustomerTypeController> _logger;
        private readonly IMapper _mapper;

        public CustomerTypeController(ICustomerTypeService CustomerTypeAppService, IMapper mapper, ILogger<CustomerTypeController> logger)
        {
            _CustomerTypeAppService = CustomerTypeAppService ?? throw new ArgumentNullException(nameof(CustomerTypeAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/CustomerTypes
        [HttpGet]
        public async Task<IEnumerable<CustomerTypeViewModel>> GetCustomerTypes()
        {
            var list = await _CustomerTypeAppService.GetCustomerTypeList();
            var mapped = _mapper.Map<IEnumerable<CustomerTypeViewModel>>(list);
            return mapped;
        }
    }
}
