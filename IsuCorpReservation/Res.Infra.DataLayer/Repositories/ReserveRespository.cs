using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using Res.Infra.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;

namespace Res.Infra.DataLayer.Repositories
{
    public class ReserveRespository : IReserveRepository
    {
        private readonly ReservationDbContext _context;

        public ReserveRespository(ReservationDbContext dbCtx)
        {
            _context = dbCtx;
        }

        public void Add(Reserve entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Reserve> entities)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserve> Find(Expression<Func<Reserve, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reserve Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserve> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reserve> GetAllReserveData()
        {
            try
            {
                var reservationDbContext = _context.Reserves.Include(r => r.Restaurant).Include(r => r.Customer).ThenInclude(r=>r.ContactType);
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

        public Reserve GetSingleOrDefault(Expression<Func<Reserve, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        
        public void UpdateReserveFavorietStatus(int id, bool state)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("ChageFavoriteStatus @p0, @p1",
                parameters: new[] { id.ToString(), state.ToString() });
            }
            catch (Exception)
            {

            }
        }

        public void UpdateReserveRanking(int id, int ranking) 
        {
            _context.Database.ExecuteSqlRaw("SetReserveRanking @p0, @p1",
                   parameters: new[] { id.ToString(), ranking.ToString() });
        }

        public int PostReserve(Reserve reserve)
        {
            try
            {
                _context.Reserves.Add(reserve);
                _context.SaveChangesAsync();

                return reserve.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public void Remove(Reserve entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Reserve> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Reserve entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Reserve> entities)
        {
            throw new NotImplementedException();
        }
    }
}
