using System.Data;
using Dapper;

namespace WebApi.Models
{
    public class CategoryProductRepository :BaseRepository
    {
        public CategoryProductRepository(IDbConnection connection) : base(connection)
        {

        }
        public int Add(List<CategoryProduct> list)
        {
            return connection.Execute("insert into CategoryProduct values (@CategoryId,@ProductId)", list); 
        }
    }
}
