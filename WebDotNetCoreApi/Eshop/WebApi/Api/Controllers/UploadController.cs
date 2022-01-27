using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        string Root => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        [HttpPost]
        public Image Add(IFormFile f)
        {
            if (f != null)
            {
                string ext = Path.GetExtension(f.FileName);
                string imageUrl = Helper.RandomString(32 - ext.Length) + ext;
                using (Stream stream = new FileStream(Path.Combine(Root, imageUrl), FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                Image image = new Image
                {
                    ContentType = f.ContentType,
                    ImageOriginal = f.FileName,
                    Size=f.Length,
                    ImageUrl = imageUrl
                };
                return image;
            }
            return null;
        }  
    }
}
