using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class CategoryRepository : BaseRepository
    {
        public CategoryRepository(CSContext context) : base(context) { }
        public List<Category> GetCategories()
        {
            
            return context.Categories.Select(p=>new Category { Id = p.Id,Name=p.Name,ParentId=p.ParentId}).ToList();
            //return context.Categories.FromSqlRaw<Category>("select * from Category").ToList();
        }
        public int Add(Category obj)
        {
            context.Categories.Add(obj);
            return context.SaveChanges();
        }
        public Category GetCategory(int id)
        {
            return context.Categories.Where(p => p.Id == id).FirstOrDefault();
        }
        public int Edit(Category obj)
        {
            context.Categories.Update(obj);
            return context.SaveChanges();
        }
        public IEnumerable<Category> GetPrents()
        {
            return context.Categories.Where(p => p.ParentId == null).Include(p => p.Children).ToList();
        }
    }
}
