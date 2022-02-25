using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        public AddressController(IConfiguration configuration) : base(configuration)
        {
        }
        [HttpPost]
        public int Add(Address obj)
        {
            return provider.Address.Add(obj);
        }
        [HttpGet("{id}")]
        public IEnumerable<Address> GetAddresses(string id)
        {
            return provider.Address.GetAddresses(id);
        }
    }
}
