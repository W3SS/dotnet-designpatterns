using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcDesignPattern.Core;
using Microsoft.AspNetCore.Mvc;

namespace MvcDesignPattern.Controllers
{
    public class SettingController : Controller
    {
        List<IReadableSettings> _readableSettings = new List<IReadableSettings>();
        List<IWritableSettings> _writableSettings = new List<IWritableSettings>();

        public SettingController()
        {
            var g = new GlobalSettings();
            var gu = new GuestSettings();

            _readableSettings.Add(g);
            _readableSettings.Add(gu);

            _writableSettings.Add(g);
        }

        public IActionResult Index()
        {
            var allSettings = SettingHelpers.GetAllSettings(_readableSettings);
            return View(allSettings);
        }

        [HttpPost]
        public IActionResult Save()
        {
            var newSettings = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "Title", "Music" }
                }
            };
            var model = SettingHelpers.SetAllSettings(_writableSettings, newSettings);

            return View(model);
        }
    }
}