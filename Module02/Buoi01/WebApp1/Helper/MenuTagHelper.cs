using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using WebApp1.Models;

namespace WebApp1.Helper
{
    public class MenuTagHelper: TagHelper
    {
        public IEnumerable<Category> Categories { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            output.Attributes.SetAttribute("class", "navbar-nav");
            List<string> list = new List<string>();
            foreach (var category in Categories)
            {
                list.Add("<li class=\"nav-item dropdown\">");
                list.Add($"<a class=\"nav-link dropdown-toggle\" data-bs-toggle=\"dropdown\" href=\"#\">{category.Name}</a>");
                if (category.Children != null)
                {
                    Recursive(list, category.Children);
                }
                list.Add("</li>");
            }
            output.Content.SetHtmlContent(string.Join("", list));
        }

        public void Recursive(List<string> list, List<Category> children,string submenu="")
        {
            list.Add($"<ul class=\"dropdown-menu{submenu}\">");
            foreach (var category in children)
            {
                list.Add("<li>");
                
                if (category.Children != null)
                {
                    list.Add($"<a class=\"dropdown-item\" href=\"#\">{category.Name} &raquo</a>");
                    Recursive(list, category.Children," submenu");
                }
                else
                {
                    list.Add($"<a class=\"dropdown-item\" href=\"#\">{category.Name}</a>");
                }
                list.Add("</li>");
            }
            list.Add("</ul>");
        }
    }
}
