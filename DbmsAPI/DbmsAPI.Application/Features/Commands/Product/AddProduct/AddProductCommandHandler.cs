using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Product.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddProductCommandHandler(IProductWriteRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _productWriteRepository.AddAsync(new()
                {
                    ProductName = request.ProductName,
                    Description = request.Description,
                    CategoryId = Guid.Parse(request.CategoryId)
                });
                await _productWriteRepository.SaveAsync();

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
