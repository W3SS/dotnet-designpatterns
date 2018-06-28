using System.Collections.Generic;
using System.Drawing;

namespace MvcDesignPattern.Core
{
    public interface IChart
    {
        string Title { get; set; }
        List<string> XData { get; set; }
        List<int> YData { get; set; }
        Bitmap GenerateChart();
    }
}
