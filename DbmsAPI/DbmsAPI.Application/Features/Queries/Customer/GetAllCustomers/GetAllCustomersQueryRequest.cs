using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQueryRequest : IRequest<List<GetAllCustomersQueryResponse>>
    {
    }
}
