using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class UploadController : Controller
    {

        SiteProvider provider;
        public UploadController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile f)
        {
            if (f != null)
            {
                Image image =await provider.Upload.Add(f);
                return Json(image);
            }
            return NotFound();
        }
    }
}
