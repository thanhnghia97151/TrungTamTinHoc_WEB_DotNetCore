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
            return connection.Execute("insert into Address(MemberId,AddressName,WardId,Phone,FullName,IsDefault) values (@MemberId,@AddressName,@WardId,@Phone,@FullName,@IsDefault)", new {obj.MemberId, obj.AddressName, obj.WardId, obj.FullName, obj.Phone,obj.IsDefault });
        }
        public IEnumerable<Address> GetAddresses(string id)
        {
            return connection.Query<Address>("GetAddressesByMember", new {Id = id},commandType:CommandType.StoredProcedure);
        }
    }
}
