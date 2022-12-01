using OrderMicroservice.Domain.Common;

namespace OrderMicroservice.Domain
{
    public class OrderItem : BaseDomainEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
