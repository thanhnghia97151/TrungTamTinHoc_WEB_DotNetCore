using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class WardRepository : BaseRepository
    {
        public WardRepository(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<Ward> GetWards()
        {
            return connection.Query<Ward>("select * from Ward");
        }
        public IEnumerable<Ward> GetWards(short id)
        {
            return connection.Query<Ward>("select * from Ward where DistrictId = @Id", new { Id = id });
        }
    }
}
