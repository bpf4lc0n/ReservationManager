using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    public class CreateReserveInput
    {
        public int? AssignedReserveId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public DateTime DateReserve { get; set; }
    }
}
