namespace WebClient.Models
{
    public class AddressRepository : BaseRepository
    {
        public AddressRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Add(Address obj)
        {
            return await Post<Address>("/api/address", obj);
        }
        public async Task<List<Address>> GetAddresses(string id)
        {
            return await Get<List<Address>>($"/api/address/{id}");
        }
    }
}
