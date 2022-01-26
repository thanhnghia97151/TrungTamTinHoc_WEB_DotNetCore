using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class SuperstoreRepository:BaseRepository
    {
        public SuperstoreRepository(CSContext context) : base(context) { }
        public List<Statistic> StatisticSalesByRegion()
        {
            return context.Statistics.FromSqlRaw<Statistic>("exec StatisticSalesByRegion").ToList();
        }
        public List<Superstore> GetProductById(string id)
        {
            return context.Superstores.Where(p => p.ProductId == id).ToList();
        }
        public List<Term> SearchTerm(string q)
        {
            return context.Superstores.Where(p => p.ProductName.Contains(q))
                .Select(p => new Term { Id = p.ProductId, Value = p.ProductName, Label = p.ProductName }).ToList();
        }
        public int Add(List<Superstore> list)
        {
            context.Superstores.AddRange(list);
            return context.SaveChanges();
        }
        public List<Product> Search(string q)
        {
            return context.Superstores.Where(p => p.ProductName.Contains(q)).Select(p => new Product { Id = p.ProductId, Name = p.ProductName }).ToList();
        }
        public List<Superstore> GetSuperstores()
        {
            return context.Superstores.ToList();

        }
        public List<Superstore> GetSuperstores(int page, int size, out int total)
        {
            total = (context.Superstores.Count() - 1 )/ size + 1;
            return context.Superstores.OrderBy(p => p.RowId).Skip((page - 1) * size).Take(size).ToList();
        }
        public List<Superstore> GetSuperstores(int page, int size)
        {
            return context.Superstores.OrderBy(p => p.RowId).Skip((page - 1) * size).Take(size).ToList();
        }
        public List<Superstore> SearchSuperstore(string q, int page, int size, out int total)
        {
            total = (context.Superstores.Where(p => p.CustomerName.Contains(q)).Count() - 1) / size + 1;
            return context.Superstores.Where(p => p.CustomerName.Contains(q)).OrderBy(p => p.RowId).Skip((page - 1) * size).Take(size).ToList();
        }
        public List<Superstore> SearchSuperstore(string q, int page,int size)
        {
            return context.Superstores.Where(p => p.CustomerName.Contains(q)).OrderBy(p => p.RowId)
                .Skip((page - 1) * size).Take(size).ToList();
        }
    }
}
