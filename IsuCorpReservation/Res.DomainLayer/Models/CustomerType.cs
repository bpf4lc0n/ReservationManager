using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Res.DomainLayer.Models
{
    /// <summary>
    /// Contact types for <see cref="Customer"/>
    /// At first is was design as <see cref="Enum"/>, but in the directions was includes
    /// that must be treat as a separate DB Table
    /// </summary>
    public class CustomerType : AuditableEntity
    {
        /// <summary>
        /// Customer Contact Type Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Contact Type value
        /// </summary>
        [Required]
        public string ContactType { get; set; }
    }
}
