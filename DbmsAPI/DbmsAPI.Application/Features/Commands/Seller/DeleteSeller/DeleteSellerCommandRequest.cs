using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Seller.DeleteSeller
{
    public class DeleteSellerCommandRequest : IRequest<DeleteSellerCommandResponse>
    {
        public string Id { get; set; }
    }
}
