namespace WebClient.Models
{
    public class DistrictRepository : BaseRepository
    {
        public DistrictRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<District>> GetDistricts(short id)
        {
            return await Get<List<District>>($"/api/district/{id}");
        }
    }
}
