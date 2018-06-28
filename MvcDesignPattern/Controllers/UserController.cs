using MvcDesignPattern.Core;
using Microsoft.AspNetCore.Mvc;

namespace MvcDesignPattern.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string notificationType)
        {
            var notifier = (INotifier)null;

            switch (notificationType)
            {
                case "email":
                    notifier = new EmailNotifier();
                    break;
                case "sms":
                    notifier = new SMSNotifer();
                    break;
                case "popup":
                    notifier = new PopupNotifier();
                    break;
                default:
                    break;
            }

            var mgr = new UserManager(notifier);
            mgr.ChangePassword("user1", "oldpwd", "newpwd");

            return View("Success");
        }
    }
}