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
            return View();
        }
    }
}
