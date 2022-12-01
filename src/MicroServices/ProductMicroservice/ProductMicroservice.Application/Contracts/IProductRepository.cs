using ProductMicroservice.Domain;

namespace ProductMicroservice.Application.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task UpdateProductStock(int productId, int usedStockCount);
    }
}
