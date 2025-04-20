using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _productWriteRepository.RemoveAsync(request.Id);
                await _productWriteRepository.SaveAsync();
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
