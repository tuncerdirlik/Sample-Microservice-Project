using OrderMicroservice.Application.Contracts;

namespace OrderMicroservice.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_dbContext);
        public IOrderItemRepository OrderItemRepository => _orderItemRepository ??= new OrderItemRepository(_dbContext);

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        
    }
}
