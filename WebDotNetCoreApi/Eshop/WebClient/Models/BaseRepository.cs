namespace WebClient.Models
{
    public abstract class BaseRepository
    {
        protected Uri uri;
        public BaseRepository(IConfiguration configuration)
        {
            uri = new Uri(configuration.GetSection("Url").Value);
        }
    }
}
