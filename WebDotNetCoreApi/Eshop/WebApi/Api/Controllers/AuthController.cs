using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        SiteProvider provider;
        public AuthController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }
        [HttpPost("loginoauth")]
        public object LoginOAuth(Member obj)
        {
            Member member = provider.Member.GetMemberById(obj.MemberId);
            if (member is null )
            {
                provider.Member.AddMemberByGoogle(obj);
                
            }
            obj.Roles = provider.Role.GetRoleNamesByMember(obj.MemberId);
            string token = Helper.CreateToken(obj);
            return new
            {
                Token = token,
                MemberId = obj.MemberId,
                Email = obj.Email,
                Roles = obj.Roles
            };

        }
        [HttpPost]
        public object Login(LoginModel obj)
        {
            Member member = provider.Member.Login(obj);
            if (member != null)
            {
                //code

                member.Roles = provider.Role.GetRoleNamesByMember(member.MemberId);
                //
                string token = Helper.CreateToken(member);
                return new
                {
                    Token = token,
                    MemberId = member.MemberId,
                    Email = member.Email,
                    Roles = member.Roles
                };
            }
            return null;
        }
        [HttpGet,Authorize]
        public Member GetMember()
        {
            return provider.Member.GetMemberById(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
