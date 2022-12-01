using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Api.Models;
using UI.Api.Services;
using UI.Api.Services.Contracts;

namespace UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("FilterOrders")]
        public async Task<IActionResult> FilterOrders([FromBody] OrderFilterRequest filter)
        {
            var response = await _orderService.FilterOrders(filter);

            return Ok(response);
        }
    }
}
