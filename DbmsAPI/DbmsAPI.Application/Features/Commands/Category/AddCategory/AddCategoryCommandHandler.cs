using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Category.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IUnitOfWork unitOfWork)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                if (request.ParentCategoryId is null)
                {
                    await _categoryWriteRepository.AddAsync(new()
                    {
                        CategoryName = request.CategoryName
                    });
                }
                else
                {
                    await _categoryWriteRepository.AddAsync(new()
                    {
                        CategoryName = request.CategoryName,
                        ParentCategoryId = Guid.Parse(request.ParentCategoryId)
                    });
                }
                await _categoryWriteRepository.SaveAsync();

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
