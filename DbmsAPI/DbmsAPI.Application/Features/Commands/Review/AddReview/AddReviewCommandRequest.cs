using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Review.AddReview
{
    public class AddReviewCommandRequest : IRequest<AddReviewCommandResponse>
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
    }
}
