using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Basket.DeleteBasket
{
    public class DeleteBasketCommandRequest : IRequest<DeleteBasketCommandResponse>
    {
        public string Id { get; set; }
    }
}
