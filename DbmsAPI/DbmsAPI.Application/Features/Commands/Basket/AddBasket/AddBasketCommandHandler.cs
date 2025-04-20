using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Basket.AddBasket
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, AddBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IUnitOfWork unitOfWork)
        {
            _basketWriteRepository = basketWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddBasketCommandResponse> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _basketWriteRepository.AddAsync(new()
                {
                    CustomerId = Guid.Parse(request.CustomerId)
                });
                await _basketWriteRepository.SaveAsync();

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
