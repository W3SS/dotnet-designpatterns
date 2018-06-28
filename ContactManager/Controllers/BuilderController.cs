using ContactManager.Core;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class BuilderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Build(string type)
        {
            var builder = (IComputerBuilder)null;
            switch (type)
            {
                case "home":
                    builder = new HomeComputerBuilder();
                    break;
                case "office":
                    builder = new OfficeComputerBuilder();
                    break;
                case "development":
                    builder = new DevelopmentComputerBuilder();
                    break;
                default:
                    break;
            }
            var assembler = new ComputerAssembler(builder);
            var computer = assembler.AssembleComputer();

            return View("Success", computer);
        }
    }
}