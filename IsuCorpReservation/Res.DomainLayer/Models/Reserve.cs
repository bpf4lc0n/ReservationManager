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
    /// 
    /// </summary>
    public class Reserve : Entity
    {
        /// <summary>
        /// Restaurant Id
        /// </summary>
        [Required]
        public int RestaurantId { get; set; }
        /// <summary>
        /// Restaurant value
        /// </summary>
        [Required]
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }
        /// <summary>
        /// Date of the reserve
        /// MinValue = GetDate()
        /// </summary>
        [Required]
        public DateTime DateReserve { get; set; }
        /// <summary>
        /// Customer star ranking evaluation of the reserve
        /// </summary>
        [Required]
        public int Ranking { get; set; }
        /// <summary>
        /// If the reserve is a favorite one of the customer
        /// </summary>
        [Required]
        public bool FavoriteStatus { get; set; }
        /// <summary>
        /// Customer Id that made the reserve
        /// </summary>
        [Required]
        public int CustomerId { get; set; }
        /// <summary>
        /// Customer value that made the reserve
        /// </summary>
        [Required]
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
