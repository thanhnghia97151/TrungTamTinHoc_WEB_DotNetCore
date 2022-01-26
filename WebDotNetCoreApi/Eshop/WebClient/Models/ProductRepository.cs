namespace WebClient.Models
{
    public class ProductRepository
    {
        string root;
        public ProductRepository(IConfiguration configuration)
        {
            root = configuration.GetSection("Url").Value;
        }
        public async Task<List<Product>> GetProducts()
        {
            using(HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(root);
                HttpResponseMessage message= await httpClient.GetAsync("/api/product");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<Product>>();
                }
                return null;
            }
        }
    }
}
