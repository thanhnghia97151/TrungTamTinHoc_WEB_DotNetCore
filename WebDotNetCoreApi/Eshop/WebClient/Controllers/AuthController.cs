using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class AuthController : Controller
    {
        SiteProvider provider;
        public AuthController(IConfiguration configuration)
        {
            provider=new SiteProvider(configuration); 
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await provider.Member.GetMemberAsync(User.FindFirstValue(ClaimTypes.PrimarySid)));
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Member obj)
        {
            await provider.Member.Add(obj);
            return Redirect("/auth/login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj)
        {
            ReponseLogin member = await provider.Member.Login(obj);
            if (member != null)
            {
                //Code
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,member.MemberId),
                    new Claim(ClaimTypes.Email,member.Email),
                    new Claim(ClaimTypes.Name,obj.Urs),
                    new Claim(ClaimTypes.PrimarySid,member.Token)//Chuyền thử vào PrimarySid đề test
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    IsPersistent = obj.Rem
                };
                await HttpContext.SignInAsync(principal,properties);
                return Redirect("/auth");

            }
            ModelState.AddModelError("", "Login Fail");
            return View();
        }
    }
}
