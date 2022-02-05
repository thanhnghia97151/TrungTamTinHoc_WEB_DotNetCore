using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        SiteProvider provider;
        public CartController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 

        }
        [Route("{id}")]
        public IEnumerable<Cart> GetCarts(string id)
        {
            return provider.Cart.GetCarts(id);
        }
        [HttpPost]
        public int Add(Cart obj)
        {
            return provider.Cart.Add(obj);
        }
        [HttpDelete("{cid}/{pid}")]
        public int Delete(string cid, int pid)
        {
            return provider.Cart.Delete(cid, pid);
        }
        [HttpPut]
        public int Edit(Cart obj)
        {
            return provider.Cart.Edit(obj); 
        }
        [HttpGet("count/{id}")]
        public int Count(string id) 
        { 
            return provider.Cart.Count(id);
        }

    }
}
