using System.ComponentModel.DataAnnotations;

namespace WebApp1.Models
{
    public class Statistic
    {
        [Key]
        public string Name { get; set; }
        public decimal Total { get; set; }
    }
}
