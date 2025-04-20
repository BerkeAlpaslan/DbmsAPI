using DbmsAPI.Application.Features.Commands.Basket.AddBasket;
using DbmsAPI.Application.Features.Commands.Basket.DeleteBasket;
using DbmsAPI.Application.Features.Queries.Basket.GetAllBaskets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromForm] AddBasketCommandRequest request)
        {
            AddBasketCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBaskets([FromQuery] GetAllBasketsQueryRequest request)
        {
            List<GetAllBasketsQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBasket([FromRoute] DeleteBasketCommandRequest request)
        {
            DeleteBasketCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
