using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceAutoSendMail
{
    internal class AutoSendMailRepository:IDisposable
    {
        IDbConnection connection;
        public AutoSendMailRepository(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("EShop"));  
        }
        public IEnumerable<AutoSendMail> GetAutoSendMails()
        {
            return connection.Query<AutoSendMail>("select * from AutoSendMail where IsSend =0 and SendDate <= GETDATE()");
        }
        public int Delete(List<int> list)
        {
            return connection.Execute("update AutoSendMail set IsSend = 1 where AutoSendMailId in @Ids", new {Ids = list});
        }

        public void Dispose()
        {
            if (connection !=null)
            {
                connection.Dispose();
            }
        }
    }
}
