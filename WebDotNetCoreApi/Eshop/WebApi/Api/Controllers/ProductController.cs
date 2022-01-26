using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        SiteProvider provider;
        public ProductController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IEnumerable<Product> GetProducts()
        {
            return provider.Product.GetProducts();
        }
    }
}
