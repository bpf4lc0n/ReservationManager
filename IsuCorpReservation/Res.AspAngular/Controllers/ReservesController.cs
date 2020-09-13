using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Res.ApplicationLayer.Interfaces;
using Res.ApplicationLayer.Services;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer;

namespace Res.AspAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservesController : ControllerBase
    {
        private readonly ReservationDbContext _context;

        private readonly IReserveService _iReserveService;

        public ReservesController(IReserveService iReserveService)
        {
            _iReserveService = iReserveService;
        }

        // GET: api/Reserves
        [HttpGet]
        public GetReserveOutput GetReserves()
        {
            var values = _iReserveService.GetReserves();
            return values;
        }

        // GET: api/Reserves/5
        [HttpGet("{id}")]
        public GetReserveOutput GetReserve(int id)
        {
            var reserve = _iReserveService.GetReserve(new GetReserveInput() {ReserveId = id });
            return reserve;
        }

        public void UpdateReserveFavorietStatus(int id, bool state)
        {
            _iReserveService.UpdateReserveFavorietStatus(id, state);
        }

        [HttpPut("Ranking")]
        public void UpdateReserveRanking(int id, int ranking)
        {
            _iReserveService.UpdateReserveRanking(id, ranking);
        }

        // PUT: api/Reserves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<IActionResult> PutReserve(int id, Reserve reserve)
        {
            if (id != reserve.Id)
            {
                return BadRequest();
            }

            _context.Entry(reserve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReserveExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reserves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostReserve(DateTime date, int restaurantId)
        {
            _iReserveService.CreateReserve(new CreateReserveInput() { DateReserve = date, RestaurantId = restaurantId });
        }

        // DELETE: api/Reserves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserve>> DeleteReserve(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }

            _context.Reserves.Remove(reserve);
            await _context.SaveChangesAsync();

            return reserve;
        }

        private bool ReserveExists(int id)
        {
            return _context.Reserves.Any(e => e.Id == id);
        }
    }
}
