using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class MemberInRoleRepository : BaseRepository
    {
        public MemberInRoleRepository(IDbConnection connection) : base(connection)
        {
        }
        public int Add(MemberInRole obj)
        {
            return connection.Execute("AddMemberInRole", obj, commandType: CommandType.StoredProcedure);
        }
    }
}
