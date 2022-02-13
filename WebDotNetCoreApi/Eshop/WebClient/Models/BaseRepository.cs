namespace WebClient.Models
{
    public abstract class BaseRepository
    {
        protected Uri uri;
        public BaseRepository(IConfiguration configuration)
        {
            uri = new Uri(configuration.GetSection("Url").Value);
        }
        protected async Task<int> Post<T>(string url,T obj)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage message = await client.PostAsJsonAsync<T>(url, obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
        protected async Task<Out> PostGetData<In,Out>(string url,In obj)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                HttpResponseMessage message= await httpClient.PostAsJsonAsync<In>(url,obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<Out>();
                }
                return default(Out);
            }
        }
        public async Task<T> Get<T>(string url, string token = null)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress=uri;
                if (token!=null)
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage message = await client.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<T>();
                }
                return default(T);
            }
            
        }
    }
}
