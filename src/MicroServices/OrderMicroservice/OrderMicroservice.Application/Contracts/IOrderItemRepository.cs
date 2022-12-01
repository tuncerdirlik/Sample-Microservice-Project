using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Domain;

namespace OrderMicroservice.Application.Contracts
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<IReadOnlyList<OrderItem>> GetByOrderId(int orderId);
    }
}
