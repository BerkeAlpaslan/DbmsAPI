using DbmsAPI.Application.Features.Commands.Category.AddCategory;
using DbmsAPI.Application.Features.Commands.Category.DeleteCategory;
using DbmsAPI.Application.Features.Queries.Category.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] AddCategoryCommandRequest request)
        {
            AddCategoryCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQueryRequest request)
        {
            List<GetAllCategoriesQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
        {
            DeleteCategoryCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
