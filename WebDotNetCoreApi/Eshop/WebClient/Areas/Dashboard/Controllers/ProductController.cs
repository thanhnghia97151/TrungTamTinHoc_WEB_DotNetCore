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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile f, Product product)
        {
            if (f!=null)
            {
                try
                {
                    Image image = await provider.Upload.Add(f);
                    product.ImageUrl = image.ImageUrl;
                    int ret = await provider.Product.Add(product);
                    return Redirect("/dashboard/product");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ModelState.AddModelError(string.Empty, "Please select image");
            return View(product);
        }
    }
}
