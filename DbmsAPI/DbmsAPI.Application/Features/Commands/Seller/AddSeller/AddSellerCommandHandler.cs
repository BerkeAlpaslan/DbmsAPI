using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Seller;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Seller.AddSeller
{
    public class AddSellerCommandHandler : IRequestHandler<AddSellerCommandRequest, AddSellerCommandResponse>
    {
        private readonly ISellerWriteRepository _sellerWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddSellerCommandHandler(ISellerWriteRepository sellerWriteRepository, IUnitOfWork unitOfWork)
        {
            _sellerWriteRepository = sellerWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddSellerCommandResponse> Handle(AddSellerCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _sellerWriteRepository.AddAsync(new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    Age = request.Age,
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    Phone = request.Phone,
                    Address = request.Address
                });
                await _sellerWriteRepository.SaveAsync();

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
