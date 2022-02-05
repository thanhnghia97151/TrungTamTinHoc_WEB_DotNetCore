namespace WebClient.Models
{
    public class AutoSendMailRepository : BaseRepository
    {
        public AutoSendMailRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<AutoSendMail>> GetAutoSendMails()
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage message =await client.GetAsync($"/api/autosendmail");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<List<AutoSendMail>>();
                }
                return null;
            }
        }
        public async Task<int> Add(AutoSendMail obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                HttpResponseMessage message = await client.PostAsJsonAsync($"/api/autosendmail",obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadAsAsync<int>();
                }
                return 0;
            }
        }
    }
}
