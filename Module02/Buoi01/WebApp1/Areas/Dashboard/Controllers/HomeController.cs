using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("dashboard")]
    [Authorize]
    //[AccessDashboardFilter]
    [ServiceFilter(typeof(AccessDashboardFilter))]
    public class HomeController : BaseController
    {
        public HomeController(SiteProvider provider) : base(provider) { }
        public IActionResult Index()
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //List<Access> access = provider.Access.GetAccessesByMemberId(userId);
            //ViewBag.accesses = access;
            return View();
        }
    }
}
