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
        [HttpPost]
        public object Login(LoginModel obj)
        {
            Member member = provider.Member.Login(obj);
            if (member != null)
            {
                //code
                string token = Helper.CreateToken(member);
                return new
                {
                    Token = token,
                    MemberId = member.MemberId,
                    Email = member.Email
                };
            }
            return null;
        }
        [Authorize]
        public Member GetMember()
        {
            return provider.Member.GetMemberById(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
