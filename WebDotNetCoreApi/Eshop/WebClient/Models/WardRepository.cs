namespace WebClient.Models
{
    public class WardRepository : BaseRepository
    {
        public WardRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async  Task<List<Ward>> GetWards(int id)
        {
            return await Get<List<Ward>>($"/api/ward/{id}");
        }
    }
}
