using OrderMicroservice.Domain.Common;

namespace OrderMicroservice.Domain
{
    public class Order : BaseDomainEntity
    {
        public int CustomerId { get; set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string FullAddress { get; private set; }
        public bool IsSuccess { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
