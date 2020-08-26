// =============================
// BPF
// ISU Corp Reservation
// =============================

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Res.DomainLayer.Models.Interfaces;

namespace Res.DomainLayer.Models
{
    public class AuditableEntity : IAuditableEntity
    {        
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
