using Dapper;
using System.Data;

namespace WebApi.Models
{
    
    public class ProductRepository
    {
        IDbConnection connection;
        public ProductRepository(IDbConnection connection)
        {
            this.connection = connection; 
        }
        public IEnumerable<Product> GetProducts()
        {
            return connection.Query<Product>("select * from Product");
        }
        public int Add(Product obj)
        {
            return connection.Execute("AddProduct", new {Name=obj.ProductName,Sku = obj.Sku,Price = obj.Price,SaleOff = obj.SaleOff,Material = obj.Material,ImageUrl = obj.ImageUrl,Description = obj.Description});
        }
    }
}
