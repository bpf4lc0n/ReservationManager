using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Res.AspAngular.ViewModels
{
    public class RestaurantViewModel
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<ReserveViewModel> ReserveDetails { get; set; }
    }
}
