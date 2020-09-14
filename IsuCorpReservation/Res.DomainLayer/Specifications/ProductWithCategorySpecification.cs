using Res.DomainLayer.Models;
using Res.DomainLayer.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class CustomerWithReserveSpqcifications : BaseSpecification<Customer>
    {
        public CustomerWithReserveSpqcifications(string customerName) 
            : base(p => p.Name.ToLower().Contains(customerName.ToLower()))
        {
            AddInclude(p => p.ContactType);
        }

        public CustomerWithReserveSpqcifications() : base(null)
        {
            AddInclude(p => p.ContactType);
        }
    }
}
