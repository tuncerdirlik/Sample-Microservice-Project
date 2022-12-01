using System.Net.Http.Json;
using UI.Api.Models;
using UI.Api.Services.Contracts;

namespace UI.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseResponse<ProductVM>> Create(ProductVM product)
        {
            var baseResponse = new BaseResponse<ProductVM>();

            var httpResponse = await _httpClient.PostAsJsonAsync<ProductVM>("products", product);
            baseResponse = await httpResponse.Content.ReadFromJsonAsync<BaseResponse<ProductVM>>();

            return baseResponse;
        }

        public async Task<BaseResponse<List<ProductVM>>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResponse<List<ProductVM>>>("products");
        }

        public async Task<BaseResponse<ProductVM>> GetById(int productId)
        {
            return await _httpClient.GetFromJsonAsync<BaseResponse<ProductVM>>($"products/{productId}");
        }
    }
}
