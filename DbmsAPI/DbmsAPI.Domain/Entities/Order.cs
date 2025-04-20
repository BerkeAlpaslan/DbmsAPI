using DbmsAPI.Domain.Entities.Common;
using DbmsAPI.Domain.Entities.CrossTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<ProductOrder> Products { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
