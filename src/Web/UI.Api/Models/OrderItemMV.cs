namespace UI.Api.Models
{
    public class OrderItemMV
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public ProductVM Product { get; set; }
    }
}
