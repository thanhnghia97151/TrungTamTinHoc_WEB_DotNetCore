namespace WebClient.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public int Price { get; set; }
        public decimal SaleOff { get; set; }
        public string Material { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<CategoryProduct> CategoryProducts { get; set; }
    }
}
