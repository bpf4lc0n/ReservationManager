// =============================
// BPF
// ISU Corp Reservation
// =============================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res.DomainLayer.Models
{
    public class Restaurant : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }    
        public ICollection<Reserve> ReserveDetails { get; set; }
    }
}
