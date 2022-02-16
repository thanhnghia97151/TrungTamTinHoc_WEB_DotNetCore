using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class AddressRepository : BaseRepository
    {
        public AddressRepository(IDbConnection connection) : base(connection)
        {
        }
        public int Add(Address obj)
        {
            return connection.Execute("insert into Address(MemberId,AddressName,WardId,Phone,FullName) values (@MemberId,@AddressName,@WardId,@Phone,@FullName)", new {obj.MemberId, obj.AddressName, obj.Wardid, obj.FullName, obj.Phone });
        }
        public IEnumerable<Address> GetAddresses(string id)
        {
            return connection.Query<Address>("GetAddressesByMember", new {Id = id},commandType:CommandType.StoredProcedure);
        }
    }
}
