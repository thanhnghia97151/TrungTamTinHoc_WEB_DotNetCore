using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Controllers;
using WebApp1.Models;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : BaseController
    {
        public CategoryController(SiteProvider provider) : base(provider) { }
        public IActionResult Index()
        {
            return View(provider.Category.GetCategories());
        }
        public IActionResult Create()
        {
            ViewBag.categories = new SelectList(provider.Category.GetCategories(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            provider.Category.Add(obj);
            return Redirect("/dashboard/category");
        }
        public IActionResult Edit(int id)
        {
            Category category = new Category();
            category = provider.Category.GetCategory(id);
            ViewBag.categories = new SelectList(provider.Category.GetCategories(), "Id", "Name");
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            provider.Category.Edit(obj);
            return Redirect("/dashboard/category");
        }
    }
}
