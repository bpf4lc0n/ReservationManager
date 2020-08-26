using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ReserveViewModel
    {
        public IEnumerable<Reserve> Reserves { get; set; }
    }
}
