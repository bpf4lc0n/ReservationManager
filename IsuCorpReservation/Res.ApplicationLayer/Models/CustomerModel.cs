using Res.ApplicationLayer.Models.Base;
using System;
using System.Collections.Generic;

namespace Res.ApplicationLayer.Models
{
    public class CustomerModel : BaseModel
    {
        public string Name { get; set; }
       
        public int ContactTypeId { get; set; }
        
        public CustomerTypeModel ContactType { get; set; }
       
        public string Telephone { get; set; }
      
        public DateTime DateBirth { get; set; }
      
        public string Description { get; set; }
       
        public ICollection<ReserveModel> Reserves { get; set; }
    }
}
