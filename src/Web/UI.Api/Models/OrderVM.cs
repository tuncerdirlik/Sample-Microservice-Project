namespace UI.Api.Models
{
    public class OrderVM
    {
        public int CustomerId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string FullAddress { get; set; }

        public List<OrderItemMV> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }

        public CustomerVM Customer { get; set; }
    }
}
