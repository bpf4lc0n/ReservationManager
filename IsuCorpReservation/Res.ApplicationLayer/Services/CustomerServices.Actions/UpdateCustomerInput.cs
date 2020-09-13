using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    public class UpdateCustomerInput : ICustomValidate
    {
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }

        public int CustomerTypeId { get; set; }

        public string Name { get; set; }

        public DateTime Datebirth { get; set; }

        public string Telephone { get; set; }

        public string Description { get; set; }

        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (CustomerId == 0 && string.IsNullOrEmpty(Name))
            {
                results.Add(new ValidationResult("Both of Client and Restaurant " +
                    "    can not be null in order to update a Customer!", new[] { "CustomerId", "RestaurantId" }));
            }
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            // todo
        }

        public override string ToString()
        {
            return string.Format("[UpdateCustomer > CustomerId = {0}, CustomerId = {1}, RestaurantId = {2}]", CustomerId, CustomerId, Name);
        }
    }
}
