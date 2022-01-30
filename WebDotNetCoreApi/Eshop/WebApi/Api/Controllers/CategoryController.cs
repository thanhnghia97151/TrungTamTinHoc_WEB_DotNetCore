using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [ApiController]// nhớ thêm
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        //Entity Framework

        //Module này sẽ sử dụng Dapper


        SiteProvider provider;
        public CategoryController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IEnumerable<Category> GetCategories()
        {
            return provider.Category.GetCategories();
        }
        [HttpPost]
        public int Add(Category obj)
        {
            return provider.Category.Add(obj);
        }
        //Dùng Api, Ajax mới có thể gọi được Delete
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return provider.Category.Delete(id);
        }
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return provider.Category.GetCategory(id);
        }
        //Edit
        [HttpPut]
        public int Edit(Category obj)
        {
            return provider.Category.Edit(obj);
        }
        //public string Welcome()
        // {
        //     return "Welcome!";
        // }

        [HttpGet("checked/{id}")]
        public IEnumerable<CategoryChecked> GetCategoryChecked(int id)
        {
            return provider.Category.GetCategoriesByProduct(id);
        }
    }
}
