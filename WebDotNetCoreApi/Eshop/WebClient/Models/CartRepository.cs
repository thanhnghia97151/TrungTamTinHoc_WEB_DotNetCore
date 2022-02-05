namespace WebClient.Models
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Add(Cart obj)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage message = await client.PostAsJsonAsync<Cart>($"/api/cart", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0; 
            }
        }
        public async Task<List<Cart>> GetCarts(string id)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                HttpResponseMessage message = await httpClient.GetAsync($"/api/cart/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<Cart>>();

                }
                return null; 
            }
        }
        public async Task<int> Delete(string cartId,int productId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                HttpResponseMessage message = await httpClient.DeleteAsync($"/api/cart/{cartId}/{productId}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();

                }
                return 0;
            }
        }
        public async Task<int> Edit(Cart obj)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                HttpResponseMessage message = await httpClient.PutAsJsonAsync($"/api/cart",obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();

                }
                return 0;
            }
        }
        public async Task<int> Count(string cartId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                HttpResponseMessage message = await httpClient.GetAsync($"/api/cart/count/{cartId}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();

                }
                return 0;
            }
        }
    }
}
