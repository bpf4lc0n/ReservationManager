using System;
using System.Collections.Generic;
using System.Text;
using Res.DomainLayer.Interfaces;

namespace Res.DomainLayer
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IRestaurantRepository Restaurants { get; }
        IReserveRepository Reserves { get; }


        int SaveChanges();
    }
}
