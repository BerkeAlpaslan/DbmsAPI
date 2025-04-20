using DbmsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Customer : User
    {
        public Basket? Basket { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
