using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApp1.Controllers;
using WebApp1.Models;
using HtmlAgilityPack;


namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ImageController : BaseController
    {
        public ImageController(SiteProvider provider) : base(provider) { }
        string Root => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        public IActionResult Clipboard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Clipboard(IFormFile f)
        {
            if(f != null )
            {
                string ext = Path.GetExtension(f.FileName);
                string url = Helper.Helper.RandomString(32 - ext.Length) + ext;
                using (Stream stream = new  FileStream(Path.Combine(Root, url), FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                return Json(provider.Image.Add(new Image
                {
                    Id=Guid.NewGuid(),
                    Original = f.FileName,
                    Size = f.Length,
                    Type= f.ContentType,
                    Url = url
                }));
                 
            }
            return NotFound();
        }
        public IActionResult Folder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Folder(IFormFile[] tf)
        {
            string root = Root;
            List<Image> list = new List<Image>();
            foreach (IFormFile item in tf)
            {
                string folder = Path.GetDirectoryName(item.FileName);
                string dir = Path.Combine(root, folder);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string ext = Path.GetExtension(item.FileName);
                string imageUrl =folder + "/" + Helper.Helper.RandomString(32 - ext.Length - folder.Length-1)+ext;
                using(Stream stream = new FileStream(imageUrl, FileMode.Create))
                {
                    item.CopyTo(stream);
                }
                list.Add(new Image
                {
                    Id = Guid.NewGuid(),
                    Original = item.FileName,
                    Size = item.Length,
                    Type = item.ContentType,
                    Url = imageUrl
                });
            }
            provider.Image.Add(list);
            return Redirect("/dashboard/image");
        }
        public IActionResult DragAndDrop()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DragAndDrop(IFormFile[] af)
        {
            if (af!=null)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                List<Image> list = new List<Image>();
                foreach (IFormFile f in af)
                {
                    string extension = Path.GetExtension(f.FileName);
                    string imageUrl = Helper.Helper.RandomString(32 - extension.Length) + extension;
                    using (Stream stream = new FileStream(Path.Combine(root, imageUrl), FileMode.Create))
                    {
                        f.CopyTo(stream);
                    }
                    list.Add(new Image
                    {
                        Id = Guid.NewGuid(),
                        Original = f.FileName,
                        Size = f.Length,
                        Url = imageUrl,
                        Type = f.ContentType
                    });

                }
                return Json(provider.Image.Add(list));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult WebCam(string f)
        {
            byte[] bytes = Convert.FromBase64String(f);
            string fileName = Helper.Helper.RandomString(28) + ".png";
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",fileName);
            using(Stream stream = new FileStream(path, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            Image image = new Image
            {
                Id = Guid.NewGuid(),
                Original = fileName,
                Url = fileName,
                Size = bytes.Length,
                Type = "image/png"
            };
            return Json(provider.Image.Add(image));
            //return Redirect("/dashboard/image");

        }
        public IActionResult WebCam()
        {
            return View();
        }
        public IActionResult DownloadCSV()
        {
            if (HttpContext.Request.Method == "POST")
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc =  web.Load("https://www.biz.uiowa.edu/faculty/jledolter/DataMining/datatext.html");
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//ul/li/a");
                List<string> list = new List<string>();
                foreach (HtmlNode node in nodes)
                {
                    list.Add(node.GetAttributeValue("href", null));
                    string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","data");
                    string url = node.GetAttributeValue("href", null);
                    using(WebClient client = new WebClient())
                    {
                        client.DownloadFile(Path.Combine("https://www.biz.uiowa.edu/faculty/jledolter/DataMining", url), Path.Combine(root, url));
                    }

                }
                return View(list);
            }
            return View();
        }
        
        public IActionResult WebUrl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WebUrl(string url)
        {
            string extension = Path.GetExtension(url);
            string imageUrl = Helper.Helper.RandomString(32 - extension.Length) + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageUrl);
            using(WebClient client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
            Image image = new Image
            {
                Id = Guid.NewGuid(),
                Original = Path.GetFileName(url),
                Size = 0,
                Type = extension,
                Url = imageUrl
            };
            provider.Image.Add(image);
            return Redirect("/dashboard/image");
        }
        public IActionResult Index()
        {
            return View(provider.Image.GetImages());
        }
        public IActionResult Delete(Guid id)
        {
            Image image = provider.Image.GetImageById(id);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", image.Url);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                provider.Image.Delete(image);
            }
            return Redirect("/dashboard/image");
        }

        public IActionResult Ajax(IFormFile f)
        {
            if (f != null)
            {
                string extension = Path.GetExtension(f.FileName);
                string imageUrl = Helper.Helper.RandomString(32 - extension.Length) + extension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageUrl);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                Image image = new Image
                {
                    Id = Guid.NewGuid(),
                    Original = f.FileName,
                    Url = imageUrl,
                    Size = f.Length,
                    Type = f.ContentType
                };
                return Json(provider.Image.Add(image));// Trả về trạng thái 0 hoặc 1
                //return Json(image); // Trả về ảnh

            }
            return NotFound();
        }
        public IActionResult Icon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Icon(IFormFile f)
        {
            return Create(f);
        }
        public IActionResult Multiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Multiple(IFormFile[] mf)
        {
            if (mf !=null)
            {
                string root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                List<Image> list = new List<Image>();
                foreach (IFormFile item in mf)
                {
                    string extension = Path.GetExtension(item.FileName);
                    string imageUrl = Helper.Helper.RandomString(32 - extension.Length) + extension;
                    using (Stream stream = new FileStream(Path.Combine(root,imageUrl),FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    list.Add(new Image
                    {
                        Id = Guid.NewGuid(),
                        Original = item.FileName,
                        Size = item.Length,
                        Url = imageUrl,
                        Type = item.ContentType
                    });
                    
                }
                provider.Image.Add(list);
                return Redirect("/dashboard/image");
            }
            ModelState.AddModelError("", "Please choos images");
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile f)
        {
            if (f!= null)
            {
                string imageUrl = Helper.Helper.RandomString(28) + Path.GetExtension(f.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageUrl);
                using(FileStream stream =  new FileStream(path, FileMode.Create))
                {
                    f.CopyTo(stream);
                }
                Image image = new Image
                {
                    Id = Guid.NewGuid(),
                    Original = f.FileName,
                    Url = imageUrl,
                    Size = f.Length,
                    Type = f.ContentType
                };
                provider.Image.Add(image);
                return Redirect("/dashboard/image");

            }
            ModelState.AddModelError("", "Please choose image");
            return View();
        }
    }
}
