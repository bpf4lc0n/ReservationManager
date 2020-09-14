using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.DomainLayer.Interfaces
{
    /// <summary>
    /// Interface for <seealso cref="Res.Infra.DataLayer.Repositories.CustomerRespository"/>
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}
