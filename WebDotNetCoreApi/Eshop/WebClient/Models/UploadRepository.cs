namespace WebClient.Models
{
    public class UploadRepository
    {
        string root;
        public UploadRepository(IConfiguration configuration)
        {
            root = configuration.GetSection("Url").Value;
        }
        public async Task<Image> Add(IFormFile f)
        {
            
            
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(root);
                    var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(f.OpenReadStream()), "f", f.FileName);
                    
                    HttpResponseMessage message = await client.PostAsync("/api/upload", content);
                    if (message.IsSuccessStatusCode)
                    {
                        return await message.Content.ReadAsAsync<Image>();
                    }
                }

            
            return null;

        }
    }
}
