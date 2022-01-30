using Dapper;
using System.Data;

namespace WebApi.Models
{
    
    public class ProductRepository
    {
        IDbConnection connection;
        public ProductRepository(IDbConnection connection)
        {
            // sử dụng IDbConnection thì viết ngắn hơn
            //Tiết kiệm connection
            // Nhung phải tự quản lý được connection
            this.connection = connection; 
        }
        public IEnumerable<Product> GetProductByCatogoryRelation(int pid)
        {
            return connection.Query<Product>("ProductsRelation", new { ProductId=pid }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<Product> GetProductByCatogory(int id)
        {
            return connection.Query<Product>("GetProductByCategory @Id", new { Id = id });
        }
        public IEnumerable<Product> GetProducts()
        {
            return connection.Query<Product>("select * from Product");
        }
        public int Edit(Product obj)
        {
            return connection.Execute("EditProduct", new
            {
                ProductId = obj.ProductId,
                ProductName = obj.ProductName,
                Sku = obj.Sku,
                Price = obj.Price,
                SaleOff=obj.SaleOff,
                ImageUrl = obj.ImageUrl,
                Material = obj.Material,
                Description = obj.Description
            }
                ,commandType: CommandType.StoredProcedure);
        }
        public int Add(Product obj)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProductId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@Name", obj.ProductName);
            parameters.Add("@Sku", obj.Sku);
            parameters.Add("@Price", obj.Price);
            parameters.Add("@SaleOff", obj.SaleOff);
            parameters.Add("@Material", obj.Material);
            parameters.Add("@ImageUrl", obj.ImageUrl);
            parameters.Add("@Description", obj.Description);
            int ret = connection.Execute("AddProduct", parameters, commandType: CommandType.StoredProcedure);
            obj.ProductId = parameters.Get<int>("@ProductId");
            return ret;
        }
        public Product GetProductById(int id)
        {
            return connection.QueryFirstOrDefault<Product>("select * from Product where ProductId = @Id", new { Id = id });
        }

    }
}
