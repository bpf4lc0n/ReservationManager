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
    /// Restaurat Model
    /// </summary>
    public class Restaurant : Entity
    {
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
