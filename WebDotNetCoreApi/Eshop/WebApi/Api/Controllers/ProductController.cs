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
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return provider.Product.GetProducts();
        }
        [HttpPost]
        public int Add(Product obj)
        {
            int ret = provider.Product.Add(obj);
            //if (ret > 0)
            //{
            //    return obj.ProductId;
            //}
            //else return 0;
            foreach (var item in obj.CategoryProducts)
            {
                item.ProductId = obj.ProductId;
            }
            ret+=provider.CategoryProduct.Add(obj.CategoryProducts);
            return ret;
        }
        [HttpPost("addlist")]
        public  int Add(List<CategoryProduct> list)
        {
            return  provider.CategoryProduct.Add(list);
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return provider.Product.GetProductById(id);
        }
        [HttpGet("product-by-category/{id}")]
        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return provider.Product.GetProductByCatogory(id);
        }
        [HttpPut]
        public int Edit(Product obj)
        {
            // Chưa làm hình ảnh
            int ret = provider.Product.Edit(obj);
            ret+=provider.CategoryProduct.Edit(obj.CategoryProducts, obj.ProductId);
            return ret; 
        }
        [HttpGet("product-relation/{pid}")]
        public IEnumerable<Product> GetProductsRelation(int pid)
        {
            return provider.Product.GetProductByCatogoryRelation(pid);
        }
    }
}
