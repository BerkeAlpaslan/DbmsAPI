using DbmsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Seller : User
    {
        public ICollection<Advertise>? Advertises { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
