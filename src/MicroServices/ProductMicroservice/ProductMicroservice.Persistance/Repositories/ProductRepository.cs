using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Application.Contracts;
using ProductMicroservice.Domain;

namespace ProductMicroservice.Persistance.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateProductStock(int productId, int usedStockCount)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(k => k.Id == productId);
            if (product != null)
            {
                product.StockCount -= usedStockCount;
            }
        }
    }
}
