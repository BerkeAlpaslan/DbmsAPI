﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>>
    {
    }
}
