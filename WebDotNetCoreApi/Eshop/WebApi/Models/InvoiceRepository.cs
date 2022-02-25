using Dapper;
using System.Data;

namespace WebApi.Models
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository(IDbConnection connection) : base(connection)
        {
        }
        public Invoice GetInvoice(Guid id)
        {
            Invoice obj =  connection.QuerySingleOrDefault<Invoice>("select Invoice.*,FullName,AddressName from Invoice join Address on Invoice.AddressId = Address.AddressId where InvoiceId = @Id",new {Id = id});
            if (obj!=null)
            {
                obj.InvoiceDetails = connection.Query<InvoiceDetail>("select InvoiceDetail.*,ProductName, ImageUrl from InvoiceDetail join Product on InvoiceDetail.ProductId = Product.ProductId and InvoiceId = @Id", new { Id = id });
            }
            return obj;
        }
        public int Add(Invoice obj)
        {
            return connection.Execute("AddInvoice", new {InvoiceId = obj.InvoiceId,
               AddressId = obj.AddressId,
               StatusInvoiceId = obj.StatusInvoiceId,
               MemberId= obj.MemberId,
               CartId = obj.CartId
            },commandType: CommandType.StoredProcedure);
        }

    }
}
