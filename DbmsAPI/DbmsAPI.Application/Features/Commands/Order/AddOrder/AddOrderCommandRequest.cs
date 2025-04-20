using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Order.AddOrder
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {
        public string CustomerId { get; set; }
        public string SellerId { get; set; }
    }
}
