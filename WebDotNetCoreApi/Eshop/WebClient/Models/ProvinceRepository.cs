namespace WebClient.Models
{
    public class ProvinceRepository : BaseRepository
    {
        public ProvinceRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<Province>> GetProvinces()
        {
            return await Get<List<Province>>("/api/province");
        }
    }
}
