using Res.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    public class CreateCustomerInput
    {
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Datebirth { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
