using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        SiteProvider provider;
        public CategoryController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.categories = await provider.Category.GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            await provider.Category.Add(obj);
            return Redirect("/dashboard/category");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            await provider.Category.Delete(id);
            return Redirect("/dashboard/category");
        }

        public async Task<IActionResult> Edit(int id)
        {
            
            return View(await provider.Category.GetCategoryById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            await provider.Category.Edit(obj);
            return Redirect("/dashboard/category");
        }
    }
}
