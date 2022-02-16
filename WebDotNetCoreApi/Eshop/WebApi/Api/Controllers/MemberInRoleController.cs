using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberInRoleController : ControllerBase
    {
        SiteProvider provider;
        public MemberInRoleController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }
        [HttpPost]
        public int Add(MemberInRole obj)
        {
            return provider.MemberInRole.Add(obj);
        }
    }
}
