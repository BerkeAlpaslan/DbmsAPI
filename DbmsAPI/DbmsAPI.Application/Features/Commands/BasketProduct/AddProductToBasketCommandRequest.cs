using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.BasketProduct
{
    public class AddProductToBasketCommandRequest : IRequest<AddProductToBasketCommandResponse>
    {
        public string ProductId { get; set; }
        public string BasketId { get; set; }
    }
}
