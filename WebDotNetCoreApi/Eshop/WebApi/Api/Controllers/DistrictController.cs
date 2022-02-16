using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseController
    {
        public DistrictController(IConfiguration configuration) : base(configuration)
        {
        }
        [HttpGet("{id}")]
        public IEnumerable<District> GetDistricts(short id)
        {
            return provider.District.GetDistricts(id);
        }
    }
}
