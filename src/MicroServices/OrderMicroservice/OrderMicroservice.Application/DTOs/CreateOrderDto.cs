using OrderMicroservice.Domain;

namespace OrderMicroservice.Application.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public string State { get;  set; }
        public string City { get;  set; }
        public string Street { get;  set; }
        public string ZipCode { get;  set; }
        public string FullAddress { get;  set; }
        //public bool IsSuccess { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        //public decimal TotalPrice { get; set; }
    }
}
