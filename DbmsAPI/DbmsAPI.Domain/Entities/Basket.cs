using DbmsAPI.Domain.Entities.Common;
using DbmsAPI.Domain.Entities.CrossTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public ICollection<BasketProduct> Products { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
