using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Res.AspAngular.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ReserveViewModel : BaseViewModel
    {

        public string Restaurant { get; set; }

        public DateTime DateReserve { get; set; }

        public int Ranking { get; set; }

        public bool FavoriteStatus { get; set; }

        public int CustomerId { get; set; }

        public CustomerViewModel Customer { get; set; }
    }
}
