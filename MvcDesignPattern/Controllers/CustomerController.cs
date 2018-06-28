using MvcDesignPattern.Core;
using MvcDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MvcDesignPattern.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Customer> GetData(string criteria, string searchby)
        {
            List<Customer> data = null;

            switch (searchby)
            {
                case "companyname":
                    data = CustomerSearch.SearchByCompany(criteria);
                    break;
                case "contactname":
                    data = CustomerSearch.SearchByName(criteria);
                    break;
                case "country":
                    data = CustomerSearch.SearchByCountry(criteria);
                    break;
                default:
                    break;
            }

            return data;
        }

        [HttpPost]
        public IActionResult Search(string criteria, string searchby)
        {
            if (!string.IsNullOrEmpty(criteria) && !string.IsNullOrEmpty(searchby))
            {
                var model = GetData(criteria, searchby);

                ViewBag.Criteria = criteria;
                ViewBag.SearchBy = searchby;

                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public FileResult Export(string criteria, string searchby)
        {
            var data = GetData(criteria, searchby);

            string exportData = CustomerDataExporter.ExportToCsv(data);
            return File(System.Text.Encoding.ASCII.GetBytes(exportData), "application/excel");
        }
    }
}