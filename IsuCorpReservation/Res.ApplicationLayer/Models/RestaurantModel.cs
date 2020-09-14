using Res.ApplicationLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Res.ApplicationLayer.Models
{
    public class RestaurantModel : BaseModel
    {
        public string Name { get; set; }
      
        public string Icon { get; set; }

        public ICollection<ReserveModel> ReserveDetails { get; set; }
    }
}
