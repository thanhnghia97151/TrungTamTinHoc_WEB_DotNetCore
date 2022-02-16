using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : BaseController
    {
        public WardController(IConfiguration configuration) : base(configuration)
        {
        }
        [HttpGet("{id}")]
        public IEnumerable<Ward> GetWards(short id)
        {
            return provider.Ward.GetWards(id);
        }
    }
}
