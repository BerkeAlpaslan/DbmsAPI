using DbmsAPI.Application.Features.Commands.Customer.AddCustomer;
using DbmsAPI.Application.Features.Commands.Customer.DeleteCustomer;
using DbmsAPI.Application.Features.Queries.Customer.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomerCommandRequest request)
        {
            AddCustomerCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQueryRequest request)
        {
            List<GetAllCustomersQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] DeleteCustomerCommandRequest request)
        {
            DeleteCustomerCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
