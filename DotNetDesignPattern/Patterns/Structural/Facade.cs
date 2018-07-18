using System;

namespace DotNetDesignPattern.Patterns.Structural
{
    public class Bank
    {
        public bool HasSufficientSavings(Customer c)
        {
            Console.WriteLine($"Check bank for {c.Name}");
            return true;
        }
    }

    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine($"Check credit for {c.Name}");
            return true;
        }
    }

    public class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine($"Check loans for {c.Name}");
            return true;
        }
    }

    public class Customer
    {
        public string Name { get; set; }

        public Customer(string name) => Name = name;
    }

    public class Mortgage
    {
        private readonly Bank _bank;
        private readonly Loan _loan;
        private readonly Credit _credit;

        public Mortgage(Bank bank, Loan loan, Credit credit)
        {
            _bank = bank;
            _loan = loan;
            _credit = credit;
        }

        public bool IsEligible(Customer c) => _bank.HasSufficientSavings(c)
                && _loan.HasNoBadLoans(c)
                && _credit.HasGoodCredit(c);
    }
}
