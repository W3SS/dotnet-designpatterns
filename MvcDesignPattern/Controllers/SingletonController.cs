using MvcDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcDesignPattern.Controllers
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