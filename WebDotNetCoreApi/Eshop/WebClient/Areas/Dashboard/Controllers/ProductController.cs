using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        SiteProvider provider;
        public  ProductController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public async Task<IActionResult> Index()
        {

            return View(await provider.Product.GetProducts());
        }
    }
}
