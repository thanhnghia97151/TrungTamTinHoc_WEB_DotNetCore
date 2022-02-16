using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(IDbConnection connection) : base(connection)
        {
        }
        public int Add(Invoice obj)
        {
            return connection.Execute("");
        }

    }
}
