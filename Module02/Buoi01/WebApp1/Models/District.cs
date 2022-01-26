using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    [Table("District")]
    public class District
    {
        [Column("DistrictId")]
        public string Id { get; set; }
        
        public string  ProvinceId { get; set; }
        [Column("DistrictName")]
        public string Name { get; set; }

    }
}
