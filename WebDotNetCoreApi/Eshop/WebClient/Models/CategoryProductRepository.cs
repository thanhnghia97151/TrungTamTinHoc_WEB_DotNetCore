namespace WebClient.Models
{
    public class CategoryProductRepository :BaseRepository
    {
        public CategoryProductRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<int> Add(List<CategoryProduct> list)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage message =await client.PostAsJsonAsync<List<CategoryProduct>>("/api/product/addlist", list);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0; 
            }
        }
    }
}
