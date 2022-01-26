using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AjaxController : BaseController
    {
        public AjaxController(SiteProvider provider) : base(provider) { }
        public IActionResult Index()
        {
            ViewBag.provinces = new SelectList(provider.Province.GetProvinces(),"Id","Name");
            return View();
        }
        public IActionResult GetDistricts(string id)
        {
            return Json(provider.District.GetDistrictsByProvince(id));
        }
        public IActionResult GetWards(string id)
        {
            return Json(provider.Ward.GetWardsByDistrict(id));
        }
    }
}
