using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcDesignPattern.Core;
using MvcDesignPattern.Models;
using System.Collections.Generic;
using System.IO;

namespace MvcDesignPattern.Controllers
{
    public class BridgeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                var ms = new MemoryStream();
                var s = file.OpenReadStream();
                s.CopyTo(ms);
                byte[] data = ms.ToArray();
                s.Dispose();
                ms.Dispose();

                var records = new List<Customer>();
                var reader = new StringReader(System.Text.Encoding.UTF8.GetString(data));
                while (true)
                {
                    string record = reader.ReadLine();
                    if (string.IsNullOrEmpty(record))
                    {
                        break;
                    }
                    else
                    {
                        string[] cols = record.Split(',');
                        var obj = new Customer()
                        {
                            CustomerId = cols[0],
                            CompanyName = cols[1],
                            ContactName = cols[2],
                            Country = cols[3]
                        };
                        records.Add(obj);
                    }
                }
                var importer = new DataImporterBasic
                {
                    ErrorLogger = new XmlErrorLogger()
                };
                importer.Import(records);
            }
            ViewBag.Message = "Data imported from " + files.Count + " file(s). Please see error log for any errors!";
            return View("Index");
        }
    }
}