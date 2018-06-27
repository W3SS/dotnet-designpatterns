using ContactManager.Core;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactManager.Controllers
{
    public class AbstractFactoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExecuteQuery(string type, string query)
        {
            var factory = (IDatabaseFactory)null;


            if (string.IsNullOrEmpty(AppSettings.FactoryType))
            {
                if (type == "sqlclient")
                {
                    factory = new SqlClientFactory();
                }
                else
                {
                    // factory = new OleDbFactory();
                } 
            }
            else
            {
                factory = (IDatabaseFactory)Activator.CreateInstance(Type.GetType(AppSettings.FactoryType));
            }

            var helper = new DatabaseHelper(factory);
            if (query.ToLower().StartsWith("select"))
            {
                var reader = helper.ExecuteSelect(query);
                return View("ShowTable", reader);
            }
            else
            {
                var i = helper.ExecuteAction(query);
                return View("ShowResult", i);
            }
        }
    }
}