using Microsoft.AspNetCore.Mvc;
using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ChartController : BaseController
    {
        
        public ChartController(SiteProvider provider) : base(provider) { }
        public IActionResult Pie()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(provider.Superstore.StatisticSalesByRegion());
        }
        [HttpPost]
        public IActionResult Ajax()
        {
            return Json(provider.Superstore.StatisticSalesByRegion());
        }
    }
}
