using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<Member>> GetMemberAsync()
        {
            return await Get<List<Member>>("/api/member");
        } 
        public async Task<ReponseLogin> LoginOAuth(Member obj)
        {
            return await PostGetData<Member, ReponseLogin>("/api/auth/loginoauth", obj);
        }
    }
}
