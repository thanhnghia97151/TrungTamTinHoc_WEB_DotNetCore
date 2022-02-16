using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class DistrictRepository : BaseRepository
    {
        public DistrictRepository(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<District> GetDistricts()
        {
            return connection.Query<District>("select * from District");
        }
        public IEnumerable<District> GetDistricts(short id)
        {
            return connection.Query<District>("select * from District where ProvinceId =@Id",new {Id = id});
        }
    }
}
