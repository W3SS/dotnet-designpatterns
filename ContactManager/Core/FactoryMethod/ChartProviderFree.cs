namespace ContactManager.Core
{
    public class ChartProviderFree : IChartProvider
    {
        public IChart GetChart()
        {
            var chart = new BarChart();
            return chart;
        }
    }
}
