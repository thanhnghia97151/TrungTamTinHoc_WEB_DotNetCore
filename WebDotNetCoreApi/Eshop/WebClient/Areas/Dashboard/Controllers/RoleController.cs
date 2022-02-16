using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Dashboard")]
    public class RoleController : Controller
    {
        SiteProvider provider;
        public RoleController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }
        public async Task<IActionResult> Index()
        {
            return View(await provider.Role.GetRoleAsync(User.FindFirstValue(ClaimTypes.PrimarySid)));
        }
    }
}
