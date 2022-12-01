using ProductMicroservice.Domain.Common;

namespace ProductMicroservice.Domain
{
    public class Product : BaseDomainEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
