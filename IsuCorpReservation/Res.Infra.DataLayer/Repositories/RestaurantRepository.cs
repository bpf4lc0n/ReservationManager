using Res.DomainLayer.Interfaces;
using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Res.Infra.DataLayer.Repository.Base;
using System.Threading.Tasks;
using Res.DomainLayer.Specifications.Base;

namespace Res.Infra.DataLayer.Repositories
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ReservationDbContext dbCtx) : base(dbCtx)
        {          
        }
    }
}
