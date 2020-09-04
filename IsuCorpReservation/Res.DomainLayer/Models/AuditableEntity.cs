// =============================
// BPF
// ISU Corp Reservation
// =============================

using System;
using Res.DomainLayer.Models.Interfaces;

namespace Res.DomainLayer.Models
{
    /// <summary>
    /// In order to manage and control creation or modification info of entities
    /// </summary>
    public class AuditableEntity : IAuditableEntity
    {     
        /// <summary>
        /// Date of last modification
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Date when entity was created
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
