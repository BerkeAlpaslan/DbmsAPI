using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.ProductOrder.AddProductToOrder
{
    public class AddProductToOrderCommandHandler : IRequestHandler<AddProductToOrderCommandRequest, AddProductToOrderCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToOrderCommandHandler(IProductWriteRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddProductToOrderCommandResponse> Handle(AddProductToOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _productWriteRepository.AddProductToOrder(request.ProductId, request.OrderId);
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
