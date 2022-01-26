using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    [Table("Access")]
    public class Access
    {
        [Column("AccessId")]
        public Guid Id { get; set; }
        [Column("AcessName")]
        public string Name { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public string Url { get; set; }
    }
}
