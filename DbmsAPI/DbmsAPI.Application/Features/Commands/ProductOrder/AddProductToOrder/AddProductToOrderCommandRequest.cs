using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.ProductOrder.AddProductToOrder
{
    public class AddProductToOrderCommandRequest : IRequest<AddProductToOrderCommandResponse>
    {
        public string ProductId { get; set; }
        public string OrderId { get; set; }
    }
}
