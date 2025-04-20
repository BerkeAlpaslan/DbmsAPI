using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.BasketProduct
{
    public class AddProductToBasketCommandHandler : IRequestHandler<AddProductToBasketCommandRequest, AddProductToBasketCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToBasketCommandHandler(IProductWriteRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddProductToBasketCommandResponse> Handle(AddProductToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _productWriteRepository.AddProductToBasket(request.ProductId, request.BasketId);
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
