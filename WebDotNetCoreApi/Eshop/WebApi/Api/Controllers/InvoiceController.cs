using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        public InvoiceController(IConfiguration configuration) : base(configuration)
        {
        }
        [HttpGet("{id}")]
        public Invoice GetInvoice(Guid id)
        {
            return provider.Invoice.GetInvoice(id);
        }
        [HttpPost]
        public int Add(Invoice obj)
        {
            
            return provider.Invoice.Add(obj);
        }
    }
}
