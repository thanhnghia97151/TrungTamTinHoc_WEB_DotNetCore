using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class WardController : BaseController
    {
        public WardController(SiteProvider provider) : base(provider) { }
        public IActionResult Index(int id=1)
        {
            int size = 700;
            List<Ward> list = provider.Ward.GetWards(id, size, out int total);
            ViewBag.total = total;
            return View(list);
        }
    }
}
