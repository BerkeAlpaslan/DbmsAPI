using DbmsAPI.Application.Features.Commands.Seller.AddSeller;
using DbmsAPI.Application.Features.Commands.Seller.DeleteSeller;
using DbmsAPI.Application.Features.Queries.Seller.GetAllSellers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SellersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddSeller([FromForm] AddSellerCommandRequest request)
        {
            AddSellerCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSellers([FromQuery] GetAllSellersQueryRequest request)
        {
            List<GetAllSellersQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSeller([FromRoute] DeleteSellerCommandRequest request)
        {
            DeleteSellerCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
