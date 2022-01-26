using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PdfController : BaseController
    {
        public PdfController(SiteProvider provider):base(provider) { } 
        public IActionResult Detail(int id)
        {
            return View(provider.Pdf.GetPdfById(id));
        }
        public IActionResult Index()
        {
            return View(provider.Superstore.GetSuperstores(1,100));
        }
        public IActionResult Manage()
        {
            return View(provider.Pdf.GetPdfs());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile f)
        {
            if (f!=null)
            {
                string url = Helper.Helper.RandomString(28)+".pdf";
                using (Stream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pdfs", url), FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                Pdf obj = new Pdf
                {
                    Size = f.Length,
                    Url = url
                };
                provider.Pdf.Add(obj);
                return Redirect("/dashboard/pdf/manage");
            }
            return View();
        }
    }
}
