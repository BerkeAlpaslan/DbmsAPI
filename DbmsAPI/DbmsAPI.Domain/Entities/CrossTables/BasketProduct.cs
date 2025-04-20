using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities.CrossTables
{
    public class BasketProduct
    {
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
