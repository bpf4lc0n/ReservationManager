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
    public class Reserve : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public Restaurant Restaurant { get; set; }
        [Required]
        public DateTime DateReserve { get; set; }
        [Required]
        public int Ranking { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }
    }
}
