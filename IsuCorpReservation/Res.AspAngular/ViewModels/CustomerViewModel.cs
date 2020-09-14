using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Res.AspAngular.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public int ContactTypeId { get; set; }

        public CustomerTypeViewModel ContactType { get; set; }

        public string Telephone { get; set; }

        public DateTime DateBirth { get; set; }

        public string Description { get; set; }

        public ICollection<ReserveViewModel> Reserves { get; set; }
    }
}
