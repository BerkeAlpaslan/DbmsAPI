using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
