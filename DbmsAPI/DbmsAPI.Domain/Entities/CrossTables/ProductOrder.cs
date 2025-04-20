using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities.CrossTables
{
    public class ProductOrder
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
