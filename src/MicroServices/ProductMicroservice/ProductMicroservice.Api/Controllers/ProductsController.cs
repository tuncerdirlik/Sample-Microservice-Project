using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Application.CQRS.Requests.Commands;
using ProductMicroservice.Application.CQRS.Requests.Queries;
using ProductMicroservice.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<ProductDto>>>> Get()
        {
            var items = await _mediator.Send(new GetAllProductsRequest());

            return Ok(items);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<ProductDto>>> Get(int id)
        {
            var item = await _mediator.Send(new GetProductItemRequest { Id = id });

            return Ok(item);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<ProductDto>>> Post([FromBody] CreateProductDto product)
        {
            var command = new CreateProductCommand
            {
                CreateProductDto = product
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto product)
        {
            var command = new UpdateProductCommand { ProductDto = product };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }
    }
}
