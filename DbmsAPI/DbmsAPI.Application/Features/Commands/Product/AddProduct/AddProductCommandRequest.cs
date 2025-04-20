using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Product.AddProduct
{
    public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
