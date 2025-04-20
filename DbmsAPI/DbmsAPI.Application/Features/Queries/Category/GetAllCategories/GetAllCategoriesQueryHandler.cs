using DbmsAPI.Application.Repositories.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryReadRepository.GetAll(false)
                .Select(category => new GetAllCategoriesQueryResponse
                {
                    Id = category.Id.ToString(),
                    CategoryName = category.CategoryName,
                    ParentCategoryId = category.ParentCategoryId.ToString(),
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt
                }).ToListAsync();

            return categories;
        }
    }
}
