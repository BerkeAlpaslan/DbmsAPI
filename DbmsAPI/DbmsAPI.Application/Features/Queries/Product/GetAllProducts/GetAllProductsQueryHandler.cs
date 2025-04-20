using DbmsAPI.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetAll(false)
                .Select(product => new GetAllProductsQueryResponse
                {
                    Id = product.Id.ToString(),
                    ProductName = product.ProductName,
                    Description = product.Description,
                    CategoryId = product.CategoryId.ToString(),
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt
                }).ToListAsync();

            return products;
        }
    }
}
