using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Review;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Review.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, DeleteReviewCommandResponse>
    {
        private readonly IReviewWriteRepository _reviewWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IUnitOfWork unitOfWork)
        {
            _reviewWriteRepository = reviewWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteReviewCommandResponse> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _reviewWriteRepository.RemoveAsync(request.Id);
                await _reviewWriteRepository.SaveAsync();
                await _unitOfWork.CommitAsync();
                return new() { Success = true };
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return new() { Success = false };
            }
        }
    }
}
