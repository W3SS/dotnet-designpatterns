namespace ContactManager.Core
{
    public class TaxCalculatorForUS : ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }

        public decimal CalculateTaxAmount()
        {
            decimal taxAbleIncome = TotalIncome - TotalDeduction;
            return taxAbleIncome * 30 / 100;
        }
    }
}
