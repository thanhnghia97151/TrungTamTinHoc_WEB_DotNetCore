namespace WebClient.Models
{
    public class SiteProvider
    {

        //API -> client 2 server khác nhau, Api phụ thuộc đường truyền Internet => Nhanh , Chậm

        IConfiguration configuration;
        public SiteProvider(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        CategoryRepository category;
        ProductRepository product;
        UploadRepository upload;
        CategoryProductRepository categoryProduct;
        AutoSendMailRepository autoSendMail;
        CartRepository cart;
        MemberRepository member;
        public MemberRepository Member
        {
            get
            {
                if (member is null)
                {
                    member = new MemberRepository(configuration);
                }
                return member;
            }
        }
        public CartRepository Cart 
        { 
            get
            {
                if (cart is null)
                {
                    cart = new CartRepository(configuration);
                }
                return cart;
            }
        }
        public AutoSendMailRepository AutoSendMail 
        {
            get
            {
                if (autoSendMail is null)
                {
                    autoSendMail = new AutoSendMailRepository(configuration);
                }
                return autoSendMail;
            }
                
                
        }
        public CategoryProductRepository CategoryProduct
        {
            get
            {
                if (categoryProduct is null)
                {
                    categoryProduct = new CategoryProductRepository(configuration);
                }
                return categoryProduct;
            }
        }
        public UploadRepository Upload
        {
            get
            {
                if (upload is null)
                {
                    upload = new UploadRepository(configuration);
                }
                return upload;
            }
        }
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
