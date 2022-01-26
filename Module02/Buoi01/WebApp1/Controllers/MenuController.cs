using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class MenuController : BaseController
    {
        public MenuController(SiteProvider provider) : base(provider) { }
        public IActionResult Index()
        {
            // return View(provider.Category.GetCategories());
            return View(provider.Category.GetPrents());
        }
        public IActionResult Recursion() // Test Class MenuTagHelper
        {
            
            return Multiple();
        }
        public IActionResult Multiple()
        {
            List<Category> list = provider.Category.GetCategories();
            // Tự tạo ra cây phân cấp cần thiết entity framework
            List<Category> parents = new List<Category>();
            Dictionary<int,Category> dict = new Dictionary<int, Category>();    
            foreach (var item in list)
            {
                dict[item.Id] = item;
                
                if (item.ParentId!=null)
                {
                    int key = item.ParentId.Value;
                    if (dict[item.ParentId.Value].Children==null)
                    {
                        dict[key].Children = new List<Category>();

                    }
                    dict[key].Children.Add(item);
                }
                else parents.Add(item);
            }
            return View(parents);
        }
    }
}
