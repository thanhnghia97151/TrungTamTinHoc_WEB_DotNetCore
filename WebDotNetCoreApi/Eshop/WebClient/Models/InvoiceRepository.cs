namespace WebClient.Models
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Add(Invoice obj)
        {
            return await Post<Invoice>("/api/invoice", obj);
        }
        public async Task<Invoice> GetInvoiceAsync(Guid id)
        {
            return await Get<Invoice>($"/api/invoice/{id}");
        }
    }
}
