using DbmsAPI.Application.Repositories.Review;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Review.GetAllReviews
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQueryRequest, List<GetAllReviewsQueryResponse>>
    {
        private readonly IReviewReadRepository _reviewReadRepository;

        public GetAllReviewsQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<List<GetAllReviewsQueryResponse>> Handle(GetAllReviewsQueryRequest request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewReadRepository.GetAll(false)
                .Select(review => new GetAllReviewsQueryResponse
                {
                    Id = review.Id.ToString(),
                    CustomerId = review.CustomerId.ToString(),
                    ProductId = review.ProductId.ToString(),
                    Title = review.Title,
                    Rating = review.Rating.ToString(),
                    Comment = review.Comment,
                    CreatedAt = review.CreatedAt,
                    UpdatedAt = review.UpdatedAt
                }).ToListAsync();

            return reviews;
        }
    }
}
