using CommonObjects.MessageCommands;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Application.CQRS.Requests.Commands;
using OrderMicroservice.Application.CQRS.Requests.Queries;
using OrderMicroservice.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderMicroservice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator, ISendEndpointProvider sendEndpointProvider)
        {
            _mediator = mediator;
            _sendEndpointProvider = sendEndpointProvider;
        }

        // GET api/<OrdersController>/5
        [HttpPost("FilterOrders")]
        public async Task<IActionResult> Get(OrderFilterDto orderFilter)
        {
            var response = await _mediator.Send(new OrderFilterRequest { OrderFilter = orderFilter });
            return Ok(response);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderDto order)
        {
            var command = new CreateOrderCommand
            {
                CreateOrderDto = order
            };

            var response = await _mediator.Send(command);
            if (response.Success)
            {
                var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:change-product-stock-service"));
                foreach (var item in order.OrderItems)
                {
                    await sendEndpoint.Send<ChangeProductStockCommand>(new ChangeProductStockCommand
                    {
                        ProductId= item.ProductId,
                        UsedStockCount = item.Count
                    });
                }
            }

            return Ok(response);
        }

    }
}
