using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        SiteProvider provider;
        public HomeController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.categories = await provider.Category.GetCategories();
            return View(await provider.Product.GetProducts());
        }
        public async Task<IActionResult> Category(byte id)
        {
            ViewBag.categories = await provider.Category.GetCategories();
            ViewBag.category = await provider.Category.GetCategoryById(id);
            return View(await provider.Product.GetProductsByCategory(id));
        }
        public async Task<IActionResult> Detail(int id)
        {
            ViewBag.products = await provider.Product.GetProductsRelation(id);
            ViewBag.categories = await provider.Category.GetCategories();
            return View(await provider.Product.GetProductById(id));
        }
    }
}
