using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class InvoiceController : Controller
    {
        SiteProvider provider;
        public InvoiceController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(Guid id)
        {
            return View(await provider.Invoice.GetInvoiceAsync(id));
        }
    }
}
