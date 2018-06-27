using ContactManager.Core;
using Microsoft.AspNetCore.Mvc;

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
            if (type == "sqlclient")
            {
                factory = new SqlClientFactory();
            }
            else
            {
                // factory = new OleDbFactory();
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