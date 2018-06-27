namespace ContactManager.Core
{
    public class ChartProviderPaid : IChartProvider
    {
        public IChart GetChart()
        {
            var chart = new PieChart();
            return chart;
        }
    }
}
