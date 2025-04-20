using DbmsAPI.Domain.Entities.Common;
using DbmsAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Domain.Entities
{
    public class Review : BaseEntity
    {
        public Rating Rating { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
