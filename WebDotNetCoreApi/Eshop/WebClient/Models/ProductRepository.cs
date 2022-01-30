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
        public async Task<List<Product>> GetProductsByCategory(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(root);
                HttpResponseMessage message = await httpClient.GetAsync($"/api/product/product-by-category/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<Product>>();
                }
                return null;
            }
        }
        public async Task<List<Product>> GetProductsRelation(int pid)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(root);
                HttpResponseMessage message = await httpClient.GetAsync($"/api/product/product-relation/{pid}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<Product>>();
                }
                return null;
            }
        }
        public async Task<int> Add(Product obj)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message = await client.PostAsJsonAsync<Product>("/api/product", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
            
        }

        public async Task<int> Edit(Product obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message = await client.PutAsJsonAsync<Product>("/api/product", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }

        }

        public async Task<Product> GetProductById(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(root);
                HttpResponseMessage message = await httpClient.GetAsync($"/api/product/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<Product>();
                }
                return null;
            }
        }
    }
}
