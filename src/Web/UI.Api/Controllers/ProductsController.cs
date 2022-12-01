using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Api.Models;
using UI.Api.Services;
using UI.Api.Services.Contracts;

namespace UI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _producrtService;

        public ProductsController(IProductService producrtService)
        {
            _producrtService = producrtService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _producrtService.GetAllAsync();

            return Ok(items);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _producrtService.GetById(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductVM customer)
        {
            var response = await _producrtService.Create(customer);

            return Ok(response);
        }
    }
}
