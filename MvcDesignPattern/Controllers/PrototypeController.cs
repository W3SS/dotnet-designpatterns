using MvcDesignPattern.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MvcDesignPattern.Controllers
{
    public class PrototypeController : Controller
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
                var header = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var fileName = header.FileName.ToString().Trim('"');
                fileName = Path.GetFileName(fileName);

                var ms = new MemoryStream();
                var stream = file.OpenReadStream();
                stream.CopyTo(ms);
                var data = ms.ToArray();
                stream.Close();
                ms.Close();

                var upload = new UploadedFile
                {
                    FileName = fileName,
                    ContentType = file.ContentType,
                    Size = file.Length,
                    TimeStamp = DateTime.Now,
                    FileContent = data
                };

                var backup = upload.DeepCopy();

                // send upload file to main system
                // send backup to backup system
            }

            ViewBag.Message = $"{files.Count} file(s) uploaded successfully!";
            return View("Index");
        }
    }
}