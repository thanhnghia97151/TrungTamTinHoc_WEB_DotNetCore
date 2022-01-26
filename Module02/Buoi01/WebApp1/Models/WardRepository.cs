using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class WardRepository : BaseRepository
    {
        public WardRepository(CSContext context) : base(context) { }
        public List<Ward> GetWardsByDistrict(string id)
        {
            return context.Wards.Where(p => p.DistrictId == id).ToList();
        }
        public List<Ward> GetWards(int page,int size, out int total)
        {
            //Tính số dòng => tính số trang
            //Why
            total = (context.Wards.Count() - 1) / size + 1;
            //Why: (page-1 )* size;
            return context.Wards.OrderBy(p => p.Id).Skip((page - 1) * size).Take(size).ToList();
        }
    }
}
