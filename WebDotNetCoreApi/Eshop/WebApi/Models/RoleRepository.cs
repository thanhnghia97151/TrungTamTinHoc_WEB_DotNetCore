using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<Role> GetRoles()
        {
            return connection.Query<Role>("select * from Role");
        }
        public IEnumerable<string> GetRoleNamesByMember(string id)
        {
            return connection.Query<string>("GetRoleNamesByMember", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
        public IEnumerable<RoleChecked> GetRolesByMember(string id)
        {
            return connection.Query<RoleChecked>("GetRolesByMember", new { Id = id }, commandType: CommandType.StoredProcedure);
        }
        public int Add(Role obj)
        {
            return connection.Execute("insert into Role(RoleName) values (@Name)",new { Name = obj.RoleName});
        }
    }
}
