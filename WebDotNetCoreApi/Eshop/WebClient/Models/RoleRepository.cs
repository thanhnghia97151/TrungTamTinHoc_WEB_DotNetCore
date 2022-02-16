namespace WebClient.Models
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<RoleChecked>> GetRolesByMember(string id)
        {
            return await Get<List<RoleChecked>>($"/api/role/{id}");
        }
        public async Task<List<Role>> GetRoleAsync(string token)
        {
            return await Get<List<Role>>("/api/role", token);
        }
    }
}
