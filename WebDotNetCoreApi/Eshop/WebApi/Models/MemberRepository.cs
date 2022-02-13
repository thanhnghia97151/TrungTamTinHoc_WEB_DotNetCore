using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class MemberRepository : BaseRepository
    {
        public MemberRepository(IDbConnection connection) : base(connection)
        {
        }
        public IEnumerable<Member> GetMembers()
        {
            return connection.Query<Member>("select MemberId, UserName,Email,Gender from Member ");

        }
        public int Add(Member obj)
        {
            obj.MemberId = Helper.RandomString(64);
            string sql = "insert into Member(MemberId,UserName,Password,Email, Gender) values (@Id,@UserName,@Password,@Email, @Gender)";
            return connection.Execute(sql, new
            {
                Id = obj.MemberId,
                UserName = obj.UserName,
                Password =Helper.Hash(obj.Password),
                Email = obj.Email,
                Gender = obj.Gender

            }) ;
        }
        public Member Login(LoginModel login)
        {
            string sql = "select MemberId,UserName,Email,Gender from Member where UserName=@Urs and Password=@Pwd";
            return connection.QuerySingleOrDefault<Member>(sql, new 
            {
                Urs = login.Urs,
                Pwd = Helper.Hash(login.Pwd)
            }) ;
        }
        public Member GetMemberById(string id)
        {
            string sql = "select MemberId,UserName,Email,Gender from Member where MemberId = @Id";
            return connection.QuerySingleOrDefault<Member>(sql, new { Id = id });
        }
    }

}
