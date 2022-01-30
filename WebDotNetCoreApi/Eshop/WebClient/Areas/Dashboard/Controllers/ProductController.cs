using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ProductController : Controller
    {
        SiteProvider provider;
        public  ProductController(IConfiguration configuration)
        {
            provider = new SiteProvider(configuration);
        }
        public async Task<IActionResult> Detail(int id)
        {
            
            return View(await provider.Product.GetProductById(id)); 
        }
        public async Task<IActionResult> Edit(int id) 
        {
            //Chưa đúng
            ViewBag.categories = await provider.Category.GetCategoriesByProductId(id);
            return View(await provider.Product.GetProductById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile f,Product obj,int[] cid) 
        {
            if (f!=null && !string.IsNullOrEmpty(f.FileName))
            {
                Image image = await provider.Upload.Add(f);
                if (image !=null)
                {
                    obj.ImageUrl = image.ImageUrl;
                }
            }
            List<CategoryProduct> list = new List<CategoryProduct>();
            foreach (int cidItem in cid)
            {
                list.Add(new CategoryProduct
                {
                    CategoryId = cidItem,
                    ProductId = obj.ProductId
                });
            }
            obj.CategoryProducts = list;
            int ret = await provider.Product.Edit(obj);
            return Redirect("/dashboard/product");
        }
        public async Task<IActionResult> Index()
        {

            return View(await provider.Product.GetProducts());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await provider.Category.GetCategories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile f, Product product,int[] cid)
        {
            if (f!=null)
            {
                try
                {
                    Image image = await provider.Upload.Add(f);
                    product.ImageUrl = image.ImageUrl;
                    List<CategoryProduct> list =  new List<CategoryProduct>();
                    foreach (int id in cid)
                    {
                        list.Add(new CategoryProduct { CategoryId = id });
                    }
                    product.CategoryProducts = list;
                    int ret = await provider.Product.Add(product);
                    //List<CategoryProduct> list = new List<CategoryProduct>();
                    //foreach (int id in cid)
                    //{
                    //    list.Add(new CategoryProduct
                    //    {
                    //        ProductId = productId,
                    //        CategoryId = id
                    //    }) ;
                    //}
                    //await provider.CategoryProduct.Add(list);
                    return Redirect("/dashboard/product");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ModelState.AddModelError(string.Empty, "Please select image");
            return View(product);
        }
    }
}
