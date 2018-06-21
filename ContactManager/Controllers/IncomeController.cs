using ContactManager.Core;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Income income)
        {
            ICountryTaxCalculator calculator = null;

            switch (income.Country)
            {
                case "USA":
                    calculator = new TaxCalculatorForUS();
                    break;
                case "UK":
                    calculator = new TaxCalculatorForUK();
                    break;
                case "IN":
                    calculator = new TaxCalculatorForIN();
                    break;
                default:
                    break;
            }

            if (calculator != null)
            {
                calculator.TotalIncome = income.TotalIncome;
                calculator.TotalDeduction = income.TotalDeduction;

                var taxCalculator = new TaxCalculator();
                ViewBag.TotalTax = taxCalculator.Calculate(calculator);
            }

            return View(income);
        }
    }
}