using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Basket;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Basket.GetAllBaskets
{
    public class GetAllBasketsQueryHandler : IRequestHandler<GetAllBasketsQueryRequest, List<GetAllBasketsQueryResponse>>
    {
        private readonly IBasketReadRepository _basketReadRepository;

        public GetAllBasketsQueryHandler(IBasketReadRepository basketReadRepository)
        {
            _basketReadRepository = basketReadRepository;
        }

        public async Task<List<GetAllBasketsQueryResponse>> Handle(GetAllBasketsQueryRequest request, CancellationToken cancellationToken)
        {
            var baskets =  await _basketReadRepository.GetAll(false)
                .Select(basket => new GetAllBasketsQueryResponse
                {
                    Id = basket.Id.ToString(),
                    CustomerId = basket.CustomerId.ToString(),
                    CreatedAt = basket.CreatedAt,
                    UpdatedAt = basket.UpdatedAt
                }).ToListAsync();

            return baskets;
        }
    }
}
