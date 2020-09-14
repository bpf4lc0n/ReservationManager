using Res.DomainLayer.Models;
using Res.DomainLayer.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.DomainLayer.Specifications
{
    public sealed class ReserveWithCustomerAndRestaurantSpecification : BaseSpecification<Reserve>
    {
        public ReserveWithCustomerAndRestaurantSpecification(int id)
            : base(b => b.Id == id)
        {
            AddInclude(b => b.Customer);
            AddInclude(b => b.Restaurant);
        }

        public ReserveWithCustomerAndRestaurantSpecification() : base(null)
        {
            AddInclude(b => b.Customer);
            AddInclude(b => b.Restaurant);
        }
    }    
}
