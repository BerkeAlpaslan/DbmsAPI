using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Advertise.GetAllAdvertises
{
    public class GetAllAdvertisesQueryRequest : IRequest<List<GetAllAdvertisesQureyResponse>>
    {
    }
}
