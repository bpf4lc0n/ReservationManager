using Res.DomainLayer.Entities.Base;
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
    public class CustomerType : Entity
    {
        /// <summary>
        /// Contact Type value
        /// </summary>
        [Required]
        public string ContactType { get; set; }
    }
}
