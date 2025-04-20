using DbmsAPI.Application.Repositories.Advertise;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Advertise.GetAllAdvertises
{
    public class GetAllAdvertisesQueryHandler : IRequestHandler<GetAllAdvertisesQueryRequest, List<GetAllAdvertisesQureyResponse>>
    {
        private readonly IAdvertiseReadRepository _advertiseReadRepository;

        public GetAllAdvertisesQueryHandler(IAdvertiseReadRepository advertiseReadRepository)
        {
            _advertiseReadRepository = advertiseReadRepository;
        }

        public async Task<List<GetAllAdvertisesQureyResponse>> Handle(GetAllAdvertisesQueryRequest request, CancellationToken cancellationToken)
        {
            var advertises = await _advertiseReadRepository.GetAll(false)
                .Select(advertise => new GetAllAdvertisesQureyResponse
                {
                    Id = advertise.Id.ToString(),
                    SellerId = advertise.SellerId.ToString(),
                    ProductId = advertise.ProductId.ToString(),
                    Title = advertise.Title,
                    Description = advertise.Description,
                    Price = advertise.Price,
                    StockAmount = advertise.StockAmount,
                    CreatedAt = advertise.CreatedAt,
                    UpdatedAt = advertise.UpdatedAt
                }).ToListAsync();

            return advertises;
        }
    }
}
