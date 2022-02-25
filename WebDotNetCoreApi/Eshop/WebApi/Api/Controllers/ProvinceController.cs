using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : BaseController
    {
        public ProvinceController(IConfiguration configuration) : base(configuration)
        {
        }
        [HttpGet]
        public IEnumerable<Province> GetProvinces()
        {
            return provider.Province.GetProvices();
        }
    }
}
