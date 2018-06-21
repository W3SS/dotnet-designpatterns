using ContactManager.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = AppSettings.Title;

            using (AppDbContext db = new AppDbContext())
            {
                var model = db.Contacts.OrderBy(_ => _.Id);

                return View(model.ToList());
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact contact)
        {
            if (ModelState.IsValid)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();

                    ViewBag.Message = "Contact added successfully";
                }
            }

            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var contact = db.Contacts.SingleOrDefault(_ => _.Id == id);

                if (contact != null)
                {
                    db.Contacts.Remove(contact);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }
    }
}