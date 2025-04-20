using DbmsAPI.Application.Features.Commands.Review.AddReview;
using DbmsAPI.Application.Features.Commands.Review.DeleteReview;
using DbmsAPI.Application.Features.Queries.Review.GetAllReviews;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromForm] AddReviewCommandRequest request)
        {
            AddReviewCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews([FromQuery] GetAllReviewsQueryRequest request)
        {
            List<GetAllReviewsQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] DeleteReviewCommandRequest request)
        {
            DeleteReviewCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
