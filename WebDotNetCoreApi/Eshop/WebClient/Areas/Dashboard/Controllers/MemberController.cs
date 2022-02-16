using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class MemberController : Controller
    {
        SiteProvider provider;
        public MemberController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }
        public async Task<IActionResult> Index()
        {
            return View(await provider.Member.GetMemberAsync());
        }
        public async Task<IActionResult> Role(string id)
        {
            return View(await provider.Role.GetRolesByMember(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(MemberInRole obj)
        {
            return Json(await provider.MemberInRole.Add(obj));
        }
    }
}
