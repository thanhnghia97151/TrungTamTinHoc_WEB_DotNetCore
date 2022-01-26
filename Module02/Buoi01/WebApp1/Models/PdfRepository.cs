using System.Collections.Generic;
using System.Linq;

namespace WebApp1.Models
{
    public class PdfRepository :BaseRepository
    {
        public PdfRepository(CSContext context) : base(context) { }
        public List<Pdf> GetPdfs()
        {
            return context.Pdfs.ToList();
        }
        public int Add(Pdf t)
        {
            context.Pdfs.Add(t);
            return context.SaveChanges();
        }
        public Pdf GetPdfById(int id)
        {
            return context.Pdfs.Find(id);
        }
    }
}
