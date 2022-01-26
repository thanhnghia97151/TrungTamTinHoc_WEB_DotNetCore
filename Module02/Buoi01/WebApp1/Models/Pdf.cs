using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp1.Models
{
    [Table("Pdf")]
    public class Pdf
    {
        [Column("PdfId")]
        public int Id { get; set; }
        [Column("PdfUrl")]
        public string Url { get; set; }
        [Column("PdfSize")]
        public long Size { get; set; }
    }
}
