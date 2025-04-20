using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryResponse
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string SellerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
