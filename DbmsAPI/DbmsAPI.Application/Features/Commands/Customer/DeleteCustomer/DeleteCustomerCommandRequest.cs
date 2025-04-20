using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Commands.Customer.DeleteCustomer
{
    public class DeleteCustomerCommandRequest : IRequest<DeleteCustomerCommandResponse>
    {
        public string Id { get; set; }
    }
}
