using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IUnitOfWork unitOfWork)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _categoryWriteRepository.RemoveAsync(request.Id);
                await _categoryWriteRepository.SaveAsync();
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
