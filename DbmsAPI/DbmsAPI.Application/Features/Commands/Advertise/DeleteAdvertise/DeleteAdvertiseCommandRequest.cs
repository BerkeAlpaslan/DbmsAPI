using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Advertise.DeleteAdvertise
{
    public class DeleteAdvertiseCommandRequest : IRequest<DeleteAdvertiseCommandResponse>
    {
        public string Id { get; set; }
    }
}
