using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Advertise.AddAdvertise
{
    public class AddAdvertiseCommandRequest : IRequest<AddAdvertiseCommandResponse>
    {
        public string SellerId { get; set; }
        public string ProductId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
    }
}
