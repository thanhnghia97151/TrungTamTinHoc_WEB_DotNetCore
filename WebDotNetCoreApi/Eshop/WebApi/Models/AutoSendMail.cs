namespace WebApi.Models
{
    public class AutoSendMail
    {
        public int AutoSendMailId { get; set; }
        public string Email { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        
    }
}
