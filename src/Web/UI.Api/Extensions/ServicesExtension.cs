using UI.Api.Models;
using UI.Api.Services;
using UI.Api.Services.Contracts;

namespace UI.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var serviceApiSettings = Configuration.GetSection("GatewayApiSettings").Get<GatewayApiSettings>();

            services.AddHttpClient<ICustomerService, CustomerService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.BaseUrl}{serviceApiSettings.Customer.Path}");
            });

            services.AddHttpClient<IProductService, ProductService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.BaseUrl}{serviceApiSettings.Product.Path}");
            });

            services.AddHttpClient<IOrderService, OrderService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.BaseUrl}{serviceApiSettings.Order.Path}");
            });
        }
    }
}
