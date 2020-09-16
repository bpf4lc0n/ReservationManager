using Res.ApplicationLayer.Models.Base;
using System;

namespace Res.ApplicationLayer.Models
{
    public class ReserveModel : BaseModel
    {
        public string Restaurant { get; set; }

        public DateTime DateReserve { get; set; }

        public int Ranking { get; set; }

        public bool FavoriteStatus { get; set; }

        public int CustomerId { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
