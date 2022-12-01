using Microsoft.EntityFrameworkCore;
using OrderMicroservice.Application.Contracts;
using OrderMicroservice.Application.DTOs;
using OrderMicroservice.Domain;

namespace OrderMicroservice.Persistance.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Order>> FilterOrdresAsync(OrderFilterDto orderFilter)
        {
            var items = await _dbContext.Orders.Include(k => k.OrderItems)
                .Where(k => k.CreatedDate >= orderFilter.StartDate && k.CreatedDate<= orderFilter.EndDate && k.Status)
                .ToListAsync();

            return items;
        }
    }
}
