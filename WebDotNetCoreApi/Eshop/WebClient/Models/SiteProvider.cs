namespace WebClient.Models
{
    public class SiteProvider
    {
        IConfiguration configuration;
        public SiteProvider(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        CategoryRepository category;
        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductRepository(configuration);
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
