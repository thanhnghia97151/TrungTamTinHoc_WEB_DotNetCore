using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AutoSendMailController : Controller
    {
        SiteProvider provider;
        public AutoSendMailController(IConfiguration configuration)
        {
            provider =  new SiteProvider(configuration);
        }
        public async Task<IActionResult> Index()
        {
            return View(await provider.AutoSendMail.GetAutoSendMails());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AutoSendMail obj)
        {
            await provider.AutoSendMail.Add(obj);
            return Redirect("/dashboard/autosendmail");
        }
    }
}
