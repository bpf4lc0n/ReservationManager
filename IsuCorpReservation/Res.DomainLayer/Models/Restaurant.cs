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
    /// <summary>
    /// Restaurat Model
    /// </summary>
    public class Restaurant : AuditableEntity
    {
        /// <summary>
        /// Restaurant Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Restaurant Name
        /// </summary>
        [Required]
        [Column(TypeName = "nchar(50)")]
        public string Name { get; set; }      
        /// <summary>
        /// Restaurant representative icon
        /// </summary>
        public string Icon { get; set; }    
        /// <summary>
        /// Reserve made on this restaurant
        /// </summary>
        public ICollection<Reserve> ReserveDetails { get; set; }
    }
}
