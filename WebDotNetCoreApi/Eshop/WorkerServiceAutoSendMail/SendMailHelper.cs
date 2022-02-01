using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceAutoSendMail
{
    internal static class SendMailHelper
    {
        public static List<int> Send(IEnumerable<AutoSendMail> list, IConfiguration configuration )

        {
            try
            {
                IConfigurationSection section = configuration.GetSection("Mail:Gmail");
                
                SmtpClient client = new SmtpClient(section["Host"], Convert.ToInt32(section["Port"]))
                {
                    Credentials = new NetworkCredential(section["Address"],section["Password"]),
                    EnableSsl = true
                };
                MailAddress mailFrom = new MailAddress(section["Address"]);
                List<int> ids = new List<int>();
                foreach (var item in list)
                {
                    MailAddress mailTo = new MailAddress(item.Email);
                    MailMessage message = new MailMessage(mailFrom,mailTo)
                    {
                        Subject = item.Subject,
                        Body = item.Body
                    };
                    client.Send(message);
                    ids.Add(item.AutoSendMailId);
                }
                return ids;
            }
            catch (Exception e)
            {
                Console.WriteLine( e.Message );
                return null;
            }
        }
    }
}
