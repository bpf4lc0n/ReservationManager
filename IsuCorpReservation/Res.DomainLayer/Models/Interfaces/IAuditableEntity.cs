// =============================
// BPF
// ISU Corp Reservation
// =============================

using System;
using System.Collections.Generic;
using System.Text;

namespace Res.DomainLayer.Models.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
