using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Seller;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Seller.DeleteSeller
{
    public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommandRequest, DeleteSellerCommandResponse>
    {
        private readonly ISellerWriteRepository _sellerWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSellerCommandHandler(ISellerWriteRepository sellerWriteRepository, IUnitOfWork unitOfWork)
        {
            _sellerWriteRepository = sellerWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteSellerCommandResponse> Handle(DeleteSellerCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _sellerWriteRepository.RemoveAsync(request.Id);
                await _sellerWriteRepository.SaveAsync();
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
