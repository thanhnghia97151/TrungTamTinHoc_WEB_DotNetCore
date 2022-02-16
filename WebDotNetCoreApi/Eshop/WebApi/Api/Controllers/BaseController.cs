using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    public class BaseController:ControllerBase
    {
        protected SiteProvider provider;
        public BaseController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }

    }
}
