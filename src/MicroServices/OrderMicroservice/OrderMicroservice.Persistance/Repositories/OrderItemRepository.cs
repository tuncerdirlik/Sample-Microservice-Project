using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Application.Contracts;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Domain;

namespace OrderMicroservice.Persistance.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly AppDbContext _dbContext;


        public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<OrderItem>> GetByOrderId(int orderId)
        {
            var items = await _dbContext.OrderItems.Where(k => k.OrderId == orderId && k.Status).ToListAsync();
            return items;
        }
    }
}
