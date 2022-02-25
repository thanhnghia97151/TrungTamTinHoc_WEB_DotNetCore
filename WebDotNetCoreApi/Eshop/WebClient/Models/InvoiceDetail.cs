namespace WebClient.Models
{
    public class InvoiceDetail
    {
        public Guid InvoiceId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public int Price { get; set; }

        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
