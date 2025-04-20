using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Advertise;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Advertise.DeleteAdvertise
{
    public class DeleteAdvertiseCommandHandler : IRequestHandler<DeleteAdvertiseCommandRequest, DeleteAdvertiseCommandResponse>
    {
        private readonly IAdvertiseWriteRepository _advertiseWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdvertiseCommandHandler(IAdvertiseWriteRepository advertiseWriteRepository, IUnitOfWork unitOfWork)
        {
            _advertiseWriteRepository = advertiseWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteAdvertiseCommandResponse> Handle(DeleteAdvertiseCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _advertiseWriteRepository.RemoveAsync(request.Id);
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
