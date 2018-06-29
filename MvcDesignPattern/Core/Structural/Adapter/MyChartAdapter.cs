using System.Collections.Generic;
using System.Drawing;

namespace MvcDesignPattern.Core
{
    public class MyChartAdapter : ThirdPartyChartGenerator, IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<int> YData { get; set; }

        public Bitmap GenerateChart()
        {
            return DrawChart(Title, XData, YData);
        }
    }
}
