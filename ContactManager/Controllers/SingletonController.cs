using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class SingletonController : Controller
    {
        public IActionResult Index()
        {
            var metadata = WebsiteMetadata.GetInstance();
            return View(metadata);
        }
    }
}