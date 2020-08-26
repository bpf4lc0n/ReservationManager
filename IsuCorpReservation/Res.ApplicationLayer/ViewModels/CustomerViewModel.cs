using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }    
}
