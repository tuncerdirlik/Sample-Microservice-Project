using CustomerMicroService.Application.CQRS.Requests.Commands;
using CustomerMicroService.Application.CQRS.Requests.Queries;
using CustomerMicroService.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerMicroService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<CustomerDto>>>> Get()
        {
            var items = await _mediator.Send(new GetAllCustomersRequest());

            return Ok(items);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CustomerDto>>> Get(int id)
        {
            var item = await _mediator.Send(new GetCustomerItemRequest { Id = id });

            return Ok(item);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<ActionResult<BaseResponse<CustomerDto>>> Post([FromBody] CreateCustomerDto customer)
        {
            var command = new CreateCustomerCommand
            {
                CreateCustomerDto = customer
            };

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // PUT api/<CustomersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerDto customer)
        {
            var command = new UpdateCustomerCommand { CustomerDto = customer };
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}
