
using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class ProvinceRepository : BaseRepository
    {
        public ProvinceRepository(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<Province> GetProvices()
        {
            return connection.Query<Province>("select * from Province");
        }
    }
}
