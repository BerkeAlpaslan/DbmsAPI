using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Customer.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, AddCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, IUnitOfWork unitOfWork)
        {
            _customerWriteRepository = customerWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _customerWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Username = request.Username,
                    Age = request.Age,
                    Email = request.Email,
                    Password = request.Password,
                    Phone = request.Phone,
                    Address = request.Address
                });
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
