namespace WebApi.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; }
        public int AddressId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public byte StatusInvoiceId { get; set; }
        public string MemberId { get; set; }
        public string? CartId { get; set; }
        public string? AddressName { get; set; }
        public string? FullName { get;set; }
        public IEnumerable<InvoiceDetail>? InvoiceDetails { get; set; }

    }
}
