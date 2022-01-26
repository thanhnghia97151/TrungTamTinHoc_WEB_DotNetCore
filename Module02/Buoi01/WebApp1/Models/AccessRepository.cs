using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class AccessRepository : BaseRepository
    {
        public AccessRepository(CSContext context) : base(context) 
        {

        }
        public List<Access> GetAccesses()
        {
            return context.Accesses.Include(p=>p.Role).ToList();
        }
        public int Add(Access obj)
        {
            context.Accesses.Add(obj);
            return context.SaveChanges();
        }
        public Access GetAccess(Guid id)
        {
            return context.Accesses.Find(id);
        }
        public int Edit(Access obj)
        {
            context.Accesses.Update(obj);
            return context.SaveChanges();
        }
        public int Delete(List<Access> accesses)
        {
            context.Accesses.RemoveRange(accesses);
            return context.SaveChanges();
        }
        public List<Access> GetAccessesByMemberId(string id)
        {
            return context.Accesses.FromSqlRaw("GetAccessesByMemberId @Id", new SqlParameter("@Id", id)).ToList();

        }
    }
}
