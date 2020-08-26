// =============================
// BPF
// ISU Corp Reservation
// =============================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res.DomainLayer.Models
{
    /// <summary>
    /// Customer model
    /// </summary>
    public class Customer : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]        
        public string Name { get; set; }
        [Required]
        public int ContactTypeId { get; set; }
        [Required]
        public CustomerType ContactType { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }        
        public string Description { get; set; }     


        public ICollection<Reserve> Reserves { get; set; }
    }
}
