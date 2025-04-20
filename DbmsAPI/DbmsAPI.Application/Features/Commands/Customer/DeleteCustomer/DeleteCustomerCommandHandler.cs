using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Customer.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, IUnitOfWork unitOfWork)
        {
            _customerWriteRepository = customerWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _customerWriteRepository.RemoveAsync(request.Id);
                await _customerWriteRepository.SaveAsync();
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
