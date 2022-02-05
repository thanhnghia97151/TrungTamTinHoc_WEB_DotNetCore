using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoSendMailController : ControllerBase
    {
        SiteProvider provider;
        public AutoSendMailController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public IEnumerable<AutoSendMail> GetAutoSendMails()
        {
            return provider.AutoSendMail.GetAutoSendMails();
        }
        [HttpPost]
        public  int Add(AutoSendMail obj)
        {
            return provider.AutoSendMail.Add(obj);
        }
    }
}
