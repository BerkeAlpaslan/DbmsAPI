using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Basket.AddBasket
{
    public class AddBasketCommandRequest : IRequest<AddBasketCommandResponse>
    {
        public string CustomerId { get; set; }
    }
}
