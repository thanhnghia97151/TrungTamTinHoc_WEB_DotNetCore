using System.Data;
using System.Data.SqlClient;

namespace WebApi.Models
{
    public class SiteProvider
    {
        IConfiguration configuration;
        IDbConnection connection;

        public SiteProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            connection = new SqlConnection(configuration.GetConnectionString("EShop"));
            // Thiếu dóng kết nối

        }
        ProductRepository product;
        CategoryRepository category;
        CategoryProductRepository categoryProduct;
        public CategoryProductRepository CategoryProduct
        {
            get
            {
                if (categoryProduct == null)
                {
                    categoryProduct = new CategoryProductRepository(connection);
                }
                return categoryProduct; 
            }
        }
        public ProductRepository Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductRepository(connection);
                }
                return product;
            }
        }
        public CategoryRepository Category
        {
            get
            {
                if (category is null)
                {
                    category = new CategoryRepository(configuration);
                }
                return category;
            }
        }
    }
}
