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
        [HttpPost]
        public int Add(Product obj)
        {
            int ret = provider.Product.Add(obj);
            if (ret > 0)
            {
                return obj.ProductId;
            }
            else return 0;
        }
        [HttpPost("addlist")]
        public  int Add(List<CategoryProduct> list)
        {
            return  provider.CategoryProduct.Add(list);
        }
    }
}
