using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Res.ApplicationLayer.Services
{
    public class UpdateReserveInput : ICustomValidate
    {
        [Range(1, int.MaxValue)]
        public int ReserveId { get; set; }

        public int CustomerId { get; set; }

        public int RestaurantId { get; set; }

        public int Ranking { get; set; }

        public bool FavoriteStatus { get; set; }

        public DateTime DateReserve { get; set; }

        public void AddValidationErrors(List<ValidationResult> results)
        {
            if (ReserveId == 0 && RestaurantId == 0)
            {
                results.Add(new ValidationResult("Both of Client and Restaurant " +
                    "    can not be null in order to update a Reserve!", new[] { "CustomerId", "RestaurantId" }));
            }
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
           // TODO
        }

        public override string ToString()
        {
            return string.Format("[UpdateReserve > ReserveId = {0}, CustomerId = {1}, RestaurantId = {2}]", ReserveId, CustomerId, RestaurantId);
        }
    }
}
