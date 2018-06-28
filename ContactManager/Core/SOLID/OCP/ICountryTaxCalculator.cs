namespace ContactManager.Core
{
    public interface ICountryTaxCalculator
    {
        decimal TotalIncome { get; set; }
        decimal TotalDeduction { get; set; }
        decimal CalculateTaxAmount();
    }
}
