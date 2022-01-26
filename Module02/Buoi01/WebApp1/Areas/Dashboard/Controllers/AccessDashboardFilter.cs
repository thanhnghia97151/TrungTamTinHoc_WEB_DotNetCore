using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    public class AccessDashboardFilter : Attribute, IActionFilter
    {

        SiteProvider provider;
        public AccessDashboardFilter(SiteProvider provider)
        {
            this.provider = provider;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Controller is Controller controller)
            {
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    //controller.ViewBag.hello = "Xin chào các học viên";
                    string id = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    controller.ViewBag.accesses = provider.Access.GetAccessesByMemberId(id);
                }
            }
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
