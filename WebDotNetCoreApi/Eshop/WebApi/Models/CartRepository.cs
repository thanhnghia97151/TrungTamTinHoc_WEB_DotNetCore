
using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class CartRepository : BaseRepository
    {
        public CartRepository(IDbConnection connection) : base(connection)
        {
        }
        public int Delete(string cid, int pid)
        {
            return connection.Execute("DELETE FROM Cart WHERE CartId = @Cid AND ProductId = @Pid", new { Cid = cid, Pid = pid });
        }
        public IEnumerable<Cart> GetCarts(string id)
        {
            return connection.Query<Cart>("GetCarts", new { Id = id },commandType:CommandType.StoredProcedure);
        }
        public int Add(Cart obj)
        {
            return connection.Execute("AddCart", new { CartId = obj.CartId, ProductId = obj.ProductId, Quantity = obj.Quantity }, commandType: CommandType.StoredProcedure);
        }
        public int Edit(Cart obj)
        {
            string sql = "update Cart set Quantity=@Qty WHERE CartId = @Cid AND ProductId = @Pid ";
            return connection.Execute(sql, new { Qty = obj.Quantity, Cid = obj.CartId, Pid = obj.ProductId });
        }
        public int Count(string cartId)
        {
            return (int)connection.ExecuteScalar("select sum(Quantity) from Cart where CartId=@Id",new { Id=cartId});
        }
    }
}
