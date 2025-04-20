using DbmsAPI.Application.Repositories.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetAllOrdersQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderReadRepository.GetAll(false)
                .Select(order => new GetAllOrdersQueryResponse
                {
                    Id = order.Id.ToString(),
                    CustomerId = order.CustomerId.ToString(),
                    SellerId = order.SellerId.ToString(),
                    CreatedAt = order.CreatedAt,
                    UpdatedAt = order.UpdatedAt
                }).ToListAsync();

            return orders;
        }
    }
}
