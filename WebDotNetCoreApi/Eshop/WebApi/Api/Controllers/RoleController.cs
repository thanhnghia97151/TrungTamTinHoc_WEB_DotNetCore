using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        SiteProvider provider;
        public RoleController(IConfiguration configuration)
        {
            this.provider = new SiteProvider(configuration);
        }
        [Authorize(Roles ="Admin"),HttpGet]
        public IEnumerable<Role> GetRoles()
        {
            return provider.Role.GetRoles();
        }
        [HttpGet("{id}")]
        public IEnumerable<Role> GetRolesByMember(string id)
        {
            return provider.Role.GetRolesByMember(id);  
        }
        [HttpGet("role-name/{id}")]
        public IEnumerable<string> GetRoleNames(string id)
        {
            return provider.Role.GetRoleNamesByMember(id);
        }
    }
}
