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
        private readonly ILogger<ReservesController> _logger;
        private readonly IMapper _mapper;

        public ReservesController(IReserveService reserveAppService, IMapper mapper, ILogger<ReservesController> logger)
        {
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
        public async Task<ReserveViewModel> GetReserve([FromRoute] int id)
        {
            var Reserve = await _reserveAppService.GetReserveById(id);
            var mapped = _mapper.Map<ReserveViewModel>(Reserve);
            return mapped;
        }

        /// <summary>
        /// Get reserves by server-side pagination
        /// </summary>
        /// <param name="field">Data base field name that will serve as Sort By value</param>
        /// <param name="sortDirection">ASC o DESC, Sql mode</param>
        /// <param name="pageIndex">Current page view</param>
        /// <param name="pageSize">The number of elements to return</param>
        /// <returns>A collection of <see cref="ReserveViewModel"/></returns>
        [HttpGet]
        [Route("[action]")]
        //string field, SortOrder sortDirection, int pageIndex, int pageSize
        public async Task<IEnumerable<ReserveViewModel>> ByPage(
                string field, string sortDirection, int pageIndex,  int pageSize)
        {
            field ??= "DateReserve";
            sortDirection ??= "ASC";
            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 10 : pageSize;
            var list = await _reserveAppService.GetReserveByPage(field, sortDirection, pageIndex, pageSize);
            var mapped = _mapper.Map<IEnumerable<ReserveViewModel>>(list);
            return mapped;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public int GetReservesCount()
        {
            return _reserveAppService.GetReserveCount();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserve"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task PostReserve(ReserveViewModel reserve)
        {
            var mapped = _mapper.Map<ReserveModel>(reserve);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _reserveAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="reserve"></param>
       /// <returns></returns>
        [HttpPut("{id}")]
        public async Task PutReserve(ReserveViewModel reserve)
        {
            var mapped = _mapper.Map<ReserveModel>(reserve);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _reserveAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task DeleteReserve([FromRoute] int id)
        {
            var Reserve = await _reserveAppService.GetReserveById(id);

            var mapped = _mapper.Map<ReserveModel>(Reserve);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _reserveAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }
    }
}
