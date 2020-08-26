using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Res.Infra.DataLayer.Repositories
{
    public class ReserveRespository : IReserveRepository
    {
        private readonly ReservationDbContext _context;

        public ReserveRespository(ReservationDbContext dbCtx)
        {
            _context = dbCtx;
        }

        public IEnumerable<Reserve> GetAllReserveData()
        {
            try
            {
                var reservationDbContext = _context.Reserves.Include(r => r.Customer).Include(r => r.Restaurant);
                return reservationDbContext.ToList();
            }
            catch
            {
                return new List<Reserve>();
            }
        }

        public IEnumerable<Reserve> GetReserveDetails(int? id)
        {
            var reserve =  _context.Reserves
                .Include(r => r.Customer)
                .Include(r => r.Restaurant)
                .SingleOrDefault(m => m.Id == id);

            if (reserve == null)
            {
                return null;
            }

            return new List<Reserve>() { reserve };
        }
    }
}
