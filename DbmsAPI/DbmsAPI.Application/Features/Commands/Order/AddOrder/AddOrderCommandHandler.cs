using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Order.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IUnitOfWork unitOfWork)
        {
            _orderWriteRepository = orderWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _orderWriteRepository.AddAsync(new()
                {
                    CustomerId = Guid.Parse(request.CustomerId),
                    SellerId = Guid.Parse(request.SellerId)
                });
                await _orderWriteRepository.SaveAsync();

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
