using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        SiteProvider provider;
        public MemberController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        [HttpGet]
        public IEnumerable<Member> GetMembers()
        {
            return provider.Member.GetMembers();
        }
        [HttpPost]
        public int Add(Member obj)
        {
            return provider.Member.Add(obj);
        }
    }
}
