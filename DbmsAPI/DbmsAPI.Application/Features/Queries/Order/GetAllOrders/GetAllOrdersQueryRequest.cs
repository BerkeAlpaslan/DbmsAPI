﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueryRequest : IRequest<List<GetAllOrdersQueryResponse>>
    {
    }
}
