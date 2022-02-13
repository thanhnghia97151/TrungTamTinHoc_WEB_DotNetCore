namespace WebClient.Models
{
    public class MemberRepository : BaseRepository
    {
        public MemberRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Add(Member member)
        {
            return await Post<Member>("/api/member", member);
        }
        public async Task<ReponseLogin> Login(LoginModel obj)
        {
            return await PostGetData<LoginModel,ReponseLogin>("/api/auth",obj);
        }
        public async Task<Member> GetMemberAsync(string token)
        {
            return await Get<Member>("/api/auth", token);
        }
    }
}
