namespace WebClient.Models
{
    public class CategoryRepository
    {
        string root;

        public CategoryRepository(IConfiguration configuration)
        {
            root= configuration.GetSection("Url").Value;
        }
        public async Task<int> Add(Category obj)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message = await client.PostAsJsonAsync<Category>("/api/category", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
        public async Task<int> Delete(int id)
        {
            using(HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message =  await client.DeleteAsync($"/api/category/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
        public async Task<List<Category>> GetCategories()
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message = await client.GetAsync("/api/category");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<Category>>();
                }
                return null;
            }
            
        }
        public async Task<Category> GetCategoryById(int id)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message = await client.GetAsync($"/api/category/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<Category>();
                }
                return null;
            }
        }
        public async Task<int> Edit(Category category)
        {
            using (HttpClient client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(root);
                HttpResponseMessage message = await client.PutAsJsonAsync<Category>($"/api/category", category);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
    }
}
