using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
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

        //
        public IActionResult GoogleSignIn()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities
                .FirstOrDefault().Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            Member obj = new Member();
            obj.Gender = false;
            obj.Password = Helper.RandomString(16);
            foreach (var claim in claims)
            {
                switch (claim.Type)
                {
                    case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier":
                        obj.MemberId = claim.Value;
                        break;
                    case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress":
                        obj.Email = obj.UserName = claim.Value;
                        break;
                }
            }
            ReponseLogin reponse = await provider.Member.LoginOAuth(obj);
            
            if (reponse != null)
            {
                
                List<Claim> list2 = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,reponse.MemberId),
                    new Claim(ClaimTypes.Name,reponse.Email),
                    new Claim(ClaimTypes.Email,reponse.Email),
                     new Claim(ClaimTypes.PrimarySid,reponse.Token)
                };
                if (reponse.Roles != null)
                {
                    foreach (string role in reponse.Roles)
                    {
                        list2.Add(new Claim(ClaimTypes.Role, role));
                    }
                }
                ClaimsIdentity claimsIdentity = new ClaimsIdentity( list2, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    IsPersistent = false
                };
                await HttpContext.SignInAsync(principal,properties);
                return Redirect("/");
            }
            return Redirect("/auth/login");
            
        }
        //

        [Authorize]
        public async Task<IActionResult> Index()
        {
            Member test = await provider.Member.GetMemberAsync(User.FindFirstValue(ClaimTypes.PrimarySid));
            return View(await provider.Member.GetMemberAsync(User.FindFirstValue(ClaimTypes.PrimarySid)));
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/auth/login");
        }
        [HttpPost]
        public async Task<IActionResult> Register(Member obj)
        {
            await provider.Member.Add(obj);
            return Redirect("/auth/login");
        }
        public IActionResult Denied()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel obj,string returnUrl)
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
                if (member.Roles!=null)
                {
                    foreach (string role in member.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role,role));    
                    }
                }
                ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                AuthenticationProperties properties = new AuthenticationProperties
                {
                    IsPersistent = obj.Rem
                };
                await HttpContext.SignInAsync(principal,properties);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect("/auth");
                }
                else
                {
                    return Redirect(returnUrl);
                }

            }
            ModelState.AddModelError("", "Login Fail");
            return View();
        }
    }
}
