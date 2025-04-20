using DbmsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Advertise : BaseEntity
    {
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
    }
}
