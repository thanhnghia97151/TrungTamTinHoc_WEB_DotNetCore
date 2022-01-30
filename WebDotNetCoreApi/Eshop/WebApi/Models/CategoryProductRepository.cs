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
        public int Edit(List<CategoryProduct> list, int id)
        {
            string sql = "delete from CategoryProduct where ProductId = @Id";
            int ret = connection.Execute(sql, new { Id = id });
            ret+= Add(list); 
            return ret;
        }
    }
}
