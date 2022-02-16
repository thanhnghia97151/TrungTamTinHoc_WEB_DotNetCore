namespace WebApi.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public int AddressId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public byte StatusInvoiceId { get; set; }

    }
}
