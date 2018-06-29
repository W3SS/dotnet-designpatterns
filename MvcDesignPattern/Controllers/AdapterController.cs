using Microsoft.AspNetCore.Mvc;
using MvcDesignPattern.Core;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;

namespace MvcDesignPattern.Controllers
{
    public class AdapterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImageOwnComponent()
        {
            var chart = new MyChartGenerator
            {
                Title = "Hours per day"
            };

            var xData = new List<string>
            {
                "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"
            };

            var yData = new List<int>
            {
                12, 7, 4, 10, 3, 11, 5
            };

            chart.XData = xData;
            chart.YData = yData;

            var bmp = chart.GenerateChart();
            var stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            var data = stream.ToArray();
            stream.Close();

            return File(data, "image/png");
        }

        public IActionResult GetImageThirdPartyComponent()
        {
            var chart = new MyChartAdapter
            {
                Title = "Hours per day"
            };

            var xData = new List<string>
            {
                "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"
            };

            var yData = new List<int>
            {
                12, 7, 4, 10, 3, 11, 5
            };

            chart.XData = xData;
            chart.YData = yData;

            var bmp = chart.GenerateChart();
            var stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            var data = stream.ToArray();
            stream.Close();

            return File(data, "image/png");
        }
    }
}