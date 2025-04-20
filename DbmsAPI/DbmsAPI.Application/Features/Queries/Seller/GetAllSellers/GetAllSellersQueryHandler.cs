using DbmsAPI.Application.Repositories.Seller;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Seller.GetAllSellers
{
    public class GetAllSellersQueryHandler : IRequestHandler<GetAllSellersQueryRequest, List<GetAllSellersQueryResponse>>
    {
        private readonly ISellerReadRepository _sellerReadRepository;

        public GetAllSellersQueryHandler(ISellerReadRepository sellerReadRepository)
        {
            _sellerReadRepository = sellerReadRepository;
        }

        public async Task<List<GetAllSellersQueryResponse>> Handle(GetAllSellersQueryRequest request, CancellationToken cancellationToken)
        {
            var sellers = await _sellerReadRepository.GetAll(false)
                .Select(seller => new GetAllSellersQueryResponse
                {
                    Id = seller.Id.ToString(),
                    Name = seller.Name,
                    Surname = seller.Surname,
                    Username = seller.Username,
                    Age = seller.Age,
                    Email = seller.Email,
                    Password = seller.Password,
                    Phone = seller.Phone,
                    Address = seller.Address,
                    CreatedAt = seller.CreatedAt,
                    UpdatedAt = seller.UpdatedAt
                }).ToListAsync();

            return sellers;
        }
    }
}
