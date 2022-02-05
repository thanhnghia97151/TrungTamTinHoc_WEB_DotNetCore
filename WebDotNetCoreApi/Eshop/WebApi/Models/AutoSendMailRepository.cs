using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class AutoSendMailRepository:BaseRepository
    {
        public AutoSendMailRepository(IDbConnection connection) : base(connection)
        {

        }
        public IEnumerable<AutoSendMail> GetAutoSendMails()
        {
            return connection.Query<AutoSendMail>("select * from AutoSendMail");
        }
        public int Add(AutoSendMail obj)
        {
            return connection.Execute("insert into AutoSendMail (Email,Subject,Body,SendDate) values (@Email,@Subject,@Body,@SendDate)", new { Email = obj.Email, Subject = obj.Subject, Body = obj.Body, SendDate = obj.SendDate });
        }
    }
}
