using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class CartController : Controller
    {
        SiteProvider provider;
        public CartController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration); 
        }
        [Authorize]
        public async Task<IActionResult> CheckOut()
        {
            ViewBag.provinces = new SelectList(await provider.Province.GetProvinces(), "ProvinceId", "ProvinceName");

            return View();
        }
        public async Task<IActionResult> District(short id)
        {
            return null;
            //return await provider.District.GetDistricts(id)
        }
        public async Task<IActionResult> Index()
        {
            string cart = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cart))
            {
                ViewBag.total = await provider.Cart.Count(cart);
                return View(await provider.Cart.GetCarts(cart));
            }
            return Redirect("/");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cart obj)
        {
            string cart = Request.Cookies["cart"];
            // Sử dụng Cookies
            if (string.IsNullOrEmpty(cart))
            {
                CookieOptions cookieOptions = new CookieOptions
                {
                    Path = "/",
                    Expires = DateTimeOffset.UtcNow.AddDays(30),
                };
                obj.CartId = obj.CartId = Helper.RandomString(32);
                Response.Cookies.Append("cart", obj.CartId, cookieOptions);
                
            }
            else
            {
                obj.CartId = cart;
            }
            
            await provider.Cart.Add(obj);
            return Redirect("/cart");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            string cart = Request.Cookies["cart"];
            // Sử dụng Cookies
            if (!string.IsNullOrEmpty(cart))
            {
                await provider.Cart.Delete(cart, id);
                return Redirect("/cart");
            }
            return Redirect("/");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cart obj)
        {
            string cart = Request.Cookies["cart"];
            // Sử dụng Cookies
            if (!string.IsNullOrEmpty(cart))
            {
                obj.CartId = cart;
                return Json(await provider.Cart.Edit(obj));
            }
            return NotFound();
        }
    }
}
