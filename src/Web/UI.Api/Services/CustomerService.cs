using System.Net.Http.Json;
using UI.Api.Models;
using UI.Api.Services.Contracts;

namespace UI.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BaseResponse<CustomerVM>> Create(CustomerVM customer)
        {
            var baseResponse = new BaseResponse<CustomerVM>();

            var httpResponse = await _httpClient.PostAsJsonAsync<CustomerVM>("customers", customer);
            baseResponse = await httpResponse.Content.ReadFromJsonAsync<BaseResponse<CustomerVM>>();

            return baseResponse;
        }

        public async Task<BaseResponse<List<CustomerVM>>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<BaseResponse<List<CustomerVM>>>("customers");
        }

        public async Task<BaseResponse<CustomerVM>> GetById(int customerId)
        {
            return await _httpClient.GetFromJsonAsync<BaseResponse<CustomerVM>>($"customers/{customerId}");
        }
    }
}
