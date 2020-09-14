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
    public class ReservesController : ControllerBase
    {
        private readonly IReserveService _reserveAppService;
        private readonly ICustomerService _customerAppService;
        private readonly ILogger<ReservesController> _logger;
        private readonly IMapper _mapper;

        public ReservesController(IReserveService reserveAppService, ICustomerService customerAppService, IMapper mapper, ILogger<ReservesController> logger)
        {
            _reserveAppService = reserveAppService ?? throw new ArgumentNullException(nameof(reserveAppService));
            _reserveAppService = reserveAppService ?? throw new ArgumentNullException(nameof(reserveAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/Reserves
        [HttpGet]
        public async Task<IEnumerable<ReserveViewModel>> GetReserves()
        {
            var list = await _reserveAppService.GetReserveList();
            var mapped = _mapper.Map<IEnumerable<ReserveViewModel>>(list);
            return mapped;
        }

        // GET: api/Reserves/5
        [HttpGet("{id}")]
        public async Task<ReserveViewModel> GetReserve(int id)
        {
            var Reserve = await _reserveAppService.GetReserveById(id);
            var mapped = _mapper.Map<ReserveViewModel>(Reserve);
            return mapped;
        }

        // PUT: api/Reserves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        async Task PutReserve(ReserveViewModel reserve)
        {
            var mapped = _mapper.Map<ReserveModel>(reserve);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _reserveAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        // POST: api/Reserves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReserveViewModel>> PostReserve(ReserveViewModel reserve)
        {
            var mapped = _mapper.Map<ReserveModel>(reserve);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _reserveAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<ReserveViewModel>(entityDto);
            return mappedViewModel;
        }

        // DELETE: api/Reserves/5
        [HttpDelete("{id}")]
        public async Task DeleteReserve(ReserveViewModel reserve)
        {
            var mapped = _mapper.Map<ReserveModel>(reserve);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _reserveAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }
    }
}
