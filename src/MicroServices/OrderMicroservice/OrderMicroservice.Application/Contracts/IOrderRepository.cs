using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Domain;

namespace OrderMicroservice.Application.Contracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IReadOnlyList<Order>> FilterOrdresAsync(OrderFilterDto orderFilter);
    }
}
