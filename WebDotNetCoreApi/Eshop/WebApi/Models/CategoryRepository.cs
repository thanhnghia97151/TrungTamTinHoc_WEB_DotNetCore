using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace WebApi.Models
{
    public class CategoryRepository
    {
        string connectionString;
        public CategoryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("EShop");
        }
        public int Add(Category obj)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Execute("insert into Category (CategoryName) values (@Name)", new { Name = obj.CategoryName });
            }
        }
        public IEnumerable<CategoryChecked> GetCategoriesByProduct(int id)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<CategoryChecked>("GetCategoryByProduct",new { Id = id },commandType:CommandType.StoredProcedure);
            }
        }
        public IEnumerable<Category> GetCategories()
        {
            //Naive
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                return connection.Query<Category>("SELECT * FROM CATEGORY");
            }
        }
        public Category GetCategory(int id)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                //string query = "select * from Category where CategoryId = @Id";
                return connection.QuerySingleOrDefault<Category>("select * from Category where CategoryId = @Id", new { Id = id });
            }
        }
        public int Edit(Category obj)
        {
            using(IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Category SET CategoryName = @Name WHERE CategoryId=@Id";
                return connection.Execute(sql, new { Id = obj.CategoryId,Name = obj.CategoryName }) ;
            }
        }
        public int Delete(int id)
        {
            using(IDbConnection connection=new SqlConnection(connectionString))
            {
                string sql = "delete Category where CategoryId = @Id";
                return connection.Execute(sql,new { Id = id });
            }
        }
    }
}
