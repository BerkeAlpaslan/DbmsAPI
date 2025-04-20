using DbmsAPI.Domain.Entities.Common;
using DbmsAPI.Domain.Entities.CrossTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public ICollection<Advertise>? Advertises{ get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BasketProduct>? Baskets { get; set; }
        public ICollection<ProductOrder>? Orders { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
}
