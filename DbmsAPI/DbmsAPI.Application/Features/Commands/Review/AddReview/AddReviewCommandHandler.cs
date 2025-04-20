using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Review;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Review.AddReview
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommandRequest, AddReviewCommandResponse>
    {
        private readonly IReviewWriteRepository _reviewWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IUnitOfWork unitOfWork)
        {
            _reviewWriteRepository = reviewWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddReviewCommandResponse> Handle(AddReviewCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _reviewWriteRepository.AddAsync(new Domain.Entities.Review
                {
                    Rating = (Domain.Enums.Rating)request.Rating,
                    Comment = request.Comment,
                    Title = request.Title,
                    ProductId = Guid.Parse(request.ProductId),
                    CustomerId = Guid.Parse(request.CustomerId)
                });
                await _reviewWriteRepository.SaveAsync();

                await _unitOfWork.CommitAsync();
                return new() { Success = true };
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                return new() { Success = false };
            }
        }
    }
}
