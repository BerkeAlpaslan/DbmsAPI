using DbmsAPI.Application.Features.Commands.Order.AddOrder;
using DbmsAPI.Application.Features.Commands.Order.DeleteOrder;
using DbmsAPI.Application.Features.Queries.Order.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromForm] AddOrderCommandRequest request)
        {
            AddOrderCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQueryRequest request)
        {
            List<GetAllOrdersQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] DeleteOrderCommandRequest request)
        {
            DeleteOrderCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
