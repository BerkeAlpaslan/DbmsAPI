using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Advertise;
using DbmsAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Advertise.AddAdvertise
{
    public class AddAdvertiseCommandHandler : IRequestHandler<AddAdvertiseCommandRequest, AddAdvertiseCommandResponse>
    {
        private readonly IAdvertiseWriteRepository _advertiseWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddAdvertiseCommandHandler(IAdvertiseWriteRepository advertiseWriteRepository, IUnitOfWork unitOfWork)
        {
            _advertiseWriteRepository = advertiseWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddAdvertiseCommandResponse> Handle(AddAdvertiseCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _advertiseWriteRepository.AddAsync(new()
                {
                    SellerId = Guid.Parse(request.SellerId),
                    ProductId = Guid.Parse(request.ProductId),
                    Title = request.Title,
                    Description = request.Description,
                    Price = request.Price,
                    StockAmount = request.StockAmount
                });
                await _advertiseWriteRepository.SaveAsync();
                
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
