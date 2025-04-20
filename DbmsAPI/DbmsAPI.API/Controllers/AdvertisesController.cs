using DbmsAPI.Application.Features.Commands.Advertise.AddAdvertise;
using DbmsAPI.Application.Features.Commands.Advertise.DeleteAdvertise;
using DbmsAPI.Application.Features.Queries.Advertise.GetAllAdvertises;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdvertisesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdvertisesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAdvertise([FromForm] AddAdvertiseCommandRequest request)
        {
            AddAdvertiseCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdvertises([FromQuery]GetAllAdvertisesQueryRequest request)
        {
            List<GetAllAdvertisesQureyResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAdvertise([FromRoute] DeleteAdvertiseCommandRequest request)
        {
            DeleteAdvertiseCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
