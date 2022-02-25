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
        AutoSendMailRepository autoSendMail;
        CartRepository cart;
        MemberRepository member;
        RoleRepository role;
        MemberInRoleRepository memberInRole;
        ProvinceRepository province;
        DistrictRepository district;
        WardRepository ward;
        InvoiceRepository invoice;
        AddressRepository address;
        public AddressRepository Address
        {
            get
            {
                if(address is null)
                {
                    address = new AddressRepository(connection) ;
                }
                return address;
            }
        }

        public InvoiceRepository Invoice
        {
            get
            {
                if (invoice is null)
                {
                    invoice = new InvoiceRepository(connection);
                }
                return invoice;
            }
        }

        public WardRepository Ward
        {
            get
            {
                if (ward is null)
                {
                    ward = new WardRepository(connection);
                }
                return ward;
            }
        }
        public DistrictRepository District
        {
            get
            {
                if (district is null)
                {
                    district = new DistrictRepository(connection);
                }
                return district;
            }
        }
        
        public ProvinceRepository Province
        {
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(connection);
                }
                return province;
            }
        }
        public MemberInRoleRepository MemberInRole
        {
            get
            {
                if (memberInRole is null)
                {
                    memberInRole = new MemberInRoleRepository(connection);
                }
                return memberInRole;
            }
        }
        public RoleRepository Role
        {
            get
            {
                if (role is null)
                {
                    role = new RoleRepository(connection);
                }
                return role;
            }
        }
        public MemberRepository Member
        {
            get
            {
                if (member is null)
                {
                    member= new MemberRepository(connection);
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
                    cart = new CartRepository(connection);
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
                    autoSendMail = new AutoSendMailRepository(connection);
                }
                return autoSendMail;
            }
        }
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
