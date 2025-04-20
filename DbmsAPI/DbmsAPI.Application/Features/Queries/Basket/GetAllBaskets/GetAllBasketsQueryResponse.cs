using DbmsAPI.Domain.Entities.CrossTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Basket.GetAllBaskets
{
    public class GetAllBasketsQueryResponse
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
