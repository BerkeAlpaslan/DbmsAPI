using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IUnitOfWork unitOfWork)
        {
            _orderWriteRepository = orderWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _orderWriteRepository.RemoveAsync(request.Id);
                await _orderWriteRepository.SaveAsync();
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
