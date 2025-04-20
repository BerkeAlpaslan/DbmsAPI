using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Review.GetAllReviews
{
    public class GetAllReviewsQueryResponse
    {
        public string Id { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
