using DbmsAPI.Application.Features.Commands.BasketProduct;
using DbmsAPI.Application.Features.Commands.Product.AddProduct;
using DbmsAPI.Application.Features.Commands.Product.DeleteProduct;
using DbmsAPI.Application.Features.Commands.ProductOrder.AddProductToOrder;
using DbmsAPI.Application.Features.Queries.Product.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DbmsAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductCommandRequest request)
        {
            AddProductCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest request)
        {
            List<GetAllProductsQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommandRequest request)
        {
            DeleteProductCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket([FromForm] AddProductToBasketCommandRequest request)
        {
            AddProductToBasketCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductToOrder([FromForm] AddProductToOrderCommandRequest request)
        {
            AddProductToOrderCommandResponse response = await _mediator.Send(request);
            return response.Success ? Ok(response) : BadRequest();
        }
    }
}
