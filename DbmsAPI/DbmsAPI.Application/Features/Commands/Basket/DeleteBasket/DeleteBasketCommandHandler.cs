using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Basket.DeleteBasket
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommandRequest, DeleteBasketCommandResponse>
    {
        private readonly IBasketWriteRepository _basketWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IUnitOfWork unitOfWork)
        {
            _basketWriteRepository = basketWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteBasketCommandResponse> Handle(DeleteBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _basketWriteRepository.RemoveAsync(request.Id);
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
