// =============================
// BPF
// ISU Corp Reservation
// =============================

using Res.DomainLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res.DomainLayer.Models
{
    /// <summary>
    /// Customer entity model
    /// </summary>
    public class Customer : Entity
    {
        /// <summary>
        /// Customer name
        /// </summary>
        [Required]
        [Column(TypeName = "nchar(50)")]
        public string Name { get; set; }
        /// <summary>
        /// ID of the contact type (foreign id)
        /// </summary>
        [Required]
        public int ContactTypeId { get; set; }
        /// <summary>
        /// Contact Type entity
        /// </summary>
        [Required]
        public CustomerType ContactType { get; set; }
        /// <summary>
        /// Customer telephone
        /// </summary>
        [Required]
        [Column(TypeName = "nchar(15)")]
        public string Telephone { get; set; }
        /// <summary>
        /// Customer datebirth
        /// </summary>
        [Required]
        public DateTime DateBirth { get; set; }   
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }     
        /// <summary>
        /// Reserves made by the customer
        /// </summary>
        public ICollection<Reserve> Reserves { get; set; }
    }
}
