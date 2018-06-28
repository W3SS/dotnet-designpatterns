namespace MvcDesignPattern.Core
{
    public class TaxCalculator
    {
        public decimal Calculate(ICountryTaxCalculator taxCalculator)
        {
            return taxCalculator.CalculateTaxAmount();
        }
    }
}
