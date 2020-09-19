using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using System.Collections.Generic;
using Res.Infra.DataLayer.Repository.Base;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Res.Infra.DataLayer.Repositories
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(ReservationDbContext dbCtx) : base(dbCtx)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="sortDirection"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Reserve>> GetReserveByPageLinq(string field, SortOrder sortDirection, int pageIndex, int pageSize)
        {
            Func<IQueryable<Reserve>, IOrderedQueryable<Reserve>> orderBy;

            if (sortDirection == SortOrder.Ascending)
                orderBy = value => value.OrderBy(d => d.DateReserve);
            else
                orderBy = value => value.OrderByDescending(d => d.DateReserve);

            return await GetPageAsync(null, orderBy, pageIndex, pageSize, true);
        }

        public async Task<IEnumerable<Reserve>> GetReserveByPage(string field, string sortDirection, int pageIndex, int pageSize)
        {
            /*
             *  @PageNo INT ,  
	            @PageSize INT ,  
	            @SortField VARCHAR(15),
	            @SortOrder VARCHAR(4)
             */

            try
            {
                
                var pageIndexParams = new SqlParameter("pageIndex", pageIndex);
                var pageSizeParams = new SqlParameter("pageSize", pageSize);
                var sortDirectionParams = new SqlParameter("sortDirection", sortDirection);
                var fieldParams = new SqlParameter("sortField", field);
                
                return await _dbContext.Reserves
                   .FromSqlRaw("EXECUTE dbo.Usp_GetReservesByPage @pageIndex,@pageSize,@sortField,@sortDirection", 
                   pageIndexParams, pageSizeParams, fieldParams, sortDirectionParams)
                   .ToListAsync();
            }
            catch (Exception error)
            {
                throw error;
            }
            
        }
    }
}
