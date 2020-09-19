using Res.DomainLayer.Models;
using Res.DomainLayer.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class CustomerSpecifications : BaseSpecification<Customer>
    {
        public CustomerSpecifications(string customerName) 
            : base(p => p.Name.ToLower().Contains(customerName.ToLower()))
        {
            AddInclude(p => p.ContactType);
        }

        public CustomerSpecifications() : base(null)
        {
            AddInclude(p => p.ContactType);
        }
    }
}
