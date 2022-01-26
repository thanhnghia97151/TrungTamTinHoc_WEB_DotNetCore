using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS;
using Microsoft.AspNetCore.Http;
using System.IO;
using NPOI.SS.UserModel;
using WebApp1.Models;
using WebApp1.Controllers;

namespace WebApp1.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ExcelController : BaseController
    {


        public ExcelController(SiteProvider provider) : base(provider) { }
        int size = 50;
        public IActionResult Autocomplete()
        {
            return View();
        }
        public IActionResult AutocompleteJson(string term)
        {
            return Json(provider.Superstore.SearchTerm(term));
        }
        public IActionResult GetProducts(string id)
        {
            return Json(provider.Superstore.GetProductById(id));
        }
        public IActionResult Datatable()
        {
            return View(provider.Superstore.GetSuperstores());
        }
        public IActionResult LazyLoad()
        {
            //Tính tài sử dụng của function or method
            return LoadMore();
        }
        public IActionResult LoadMore()
        {
            List<Superstore> list = provider.Superstore.GetSuperstores(1, size, out int total);
            ViewBag.total = total;

            return View(list);
        }
        public IActionResult Find(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                return View();
            }
            List<Superstore> list = provider.Superstore.SearchSuperstore(q, 1, size, out int total);
            ViewBag.total = total;
            return View(list);
        }
        public IActionResult SearchJson(int id, string q)
        {
            return Json(provider.Superstore.SearchSuperstore(q, id, size));
        }
        public IActionResult LoadJson(int id)
        {
            return Json(provider.Superstore.GetSuperstores(id,size));
        }
        public IActionResult Index(string q, int id =1)
        {
            List<Superstore> list;


            int total;
            if (string.IsNullOrEmpty(q))
            {
                list = provider.Superstore.GetSuperstores(id, size, out total);
            }
            else
            {
                list = provider.Superstore.SearchSuperstore(q, id, size, out total);
            }
            ViewBag.total = total;
            return View(list);
        }
        public IActionResult Search(string q,int id = 1)
        {
            List<Superstore> list = provider.Superstore.SearchSuperstore(q, id, size, out int total);
            ViewBag.total = total;
            return View(list);
        }
        [HttpPost]
        public IActionResult Upload(IFormFile f)
        {
            if (f != null)
            {
                Stream stream = f.OpenReadStream();
                IWorkbook workbook = new HSSFWorkbook(stream);
                ISheet sheet = workbook.GetSheetAt(0);
                List<Superstore> list = new List<Superstore>();
                
                for (int i = 1; i < sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    Superstore obj = new Superstore
                    {
                        RowId = Convert.ToInt32(row.GetCell(0).NumericCellValue),
                        OrderId = row.GetCell(1).StringCellValue,
                        OrderDate = row.GetCell(2).DateCellValue,
                        ShipDate = row.GetCell(3).DateCellValue,
                        ShipMode = row.GetCell(4).StringCellValue,
                        CustomerId = row.GetCell(5).StringCellValue,
                        CustomerName = row.GetCell(6).StringCellValue,
                        Segment = row.GetCell(7).StringCellValue,
                        Country = row.GetCell(8).StringCellValue,
                        City = row.GetCell(9).StringCellValue,
                        State = row.GetCell(10).StringCellValue,
                        Region = row.GetCell(12).StringCellValue,
                        ProductId = row.GetCell(13).StringCellValue,
                        Category = row.GetCell(14).StringCellValue,
                        SubCategory = row.GetCell(15).StringCellValue,
                        ProductName = row.GetCell(16).StringCellValue,
                        Sales = Convert.ToDecimal(row.GetCell(17).NumericCellValue),
                        Quantity = Convert.ToInt16(row.GetCell(18).NumericCellValue),
                        Discount = Convert.ToDecimal(row.GetCell(19).NumericCellValue),
                        Profit = Convert.ToDecimal(row.GetCell(20).NumericCellValue),
                    };
                    try
                    {
                        obj.PostalCode = row.GetCell(11).NumericCellValue.ToString();
                    }
                    catch
                    {

                        obj.PostalCode = row.GetCell(11).StringCellValue;
                    }
                    
                    list.Add(obj);
                }
                provider.Superstore.Add(list);
                return View(list);
            }
            
            return Redirect("/dashboard/excel");
        }
    }
}
