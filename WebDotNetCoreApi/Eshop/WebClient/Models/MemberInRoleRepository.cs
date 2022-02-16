namespace WebClient.Models
{
    public class MemberInRoleRepository : BaseRepository
    {
        public MemberInRoleRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Add(MemberInRole obj)
        {
            return await Post<MemberInRole>("/api/memberinrole", obj);
        }
    }
}
