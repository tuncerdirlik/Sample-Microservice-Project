using UI.Api.Models;
using UI.Api.Services.Contracts;

namespace UI.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public OrderService(HttpClient httpClient, ICustomerService customerService, IProductService productService)
        {
            _httpClient = httpClient;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<BaseResponse<List<OrderVM>>> FilterOrders(OrderFilterRequest filter)
        {
            var baseResponse = new BaseResponse<List<OrderVM>>();

            var httpResponse = await _httpClient.PostAsJsonAsync<OrderFilterRequest>("orders/filterorders", filter);
            baseResponse = await httpResponse.Content.ReadFromJsonAsync<BaseResponse<List<OrderVM>>>();

            if (baseResponse.Success && baseResponse.Data.Any())
            {
                foreach (var item in baseResponse.Data)
                {
                    var customerResponse = await _customerService.GetById(item.CustomerId);
                    if (customerResponse.Success && customerResponse.Data != null)
                    {
                        item.Customer= customerResponse.Data;
                    }

                    if (item.OrderItems.Any())
                    {
                        foreach (var orderProducts in item.OrderItems)
                        {
                            var productResponse = await _productService.GetById(orderProducts.ProductId);
                            if (productResponse.Success && productResponse.Data != null)
                            {
                                orderProducts.Product= productResponse.Data;
                            }
                        }
                    }
                }
            }

            return baseResponse;
        }
    }
}
