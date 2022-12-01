using UI.Api.Models;

namespace UI.Api.Services.Contracts
{
    public interface IOrderService
    {
        Task<BaseResponse<List<OrderVM>>> FilterOrders(OrderFilterRequest filter);
    }
}
