namespace WebApi.Models
{
    public class InvoiceDetail
    {
        public Guid InvoiceId { get; set; }
        public int ProductId { get; set; }
        public short Quantity { get; set; }
        public int Price { get; set; }

    }
}
