using DbmsAPI.Application.Repositories;
using DbmsAPI.Application.Repositories.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application.Features.Queries.Customer.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, List<GetAllCustomersQueryResponse>>
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        public GetAllCustomersQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<List<GetAllCustomersQueryResponse>> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerReadRepository.GetAll(false)
                .Select(customer => new GetAllCustomersQueryResponse
                {
                    Id = customer.Id.ToString(),
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Username = customer.Username,
                    Age = customer.Age,
                    Email = customer.Email,
                    Password = customer.Password,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    CreatedAt = customer.CreatedAt,
                    UpdatedAt = customer.UpdatedAt
                }).ToListAsync();

            return customers;
        }
    }
}
