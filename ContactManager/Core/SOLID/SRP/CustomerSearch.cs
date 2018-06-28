using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Core
{
    public class CustomerSearch
    {
        public static List<Customer> SearchByCountry(string country)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Customers.Where(_ => _.Country.Contains(country)).OrderBy(_ => _.CustomerId).ToList();
            }
        }

        public static List<Customer> SearchByCompany(string company)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Customers.Where(_ => _.CompanyName.Contains(company)).OrderBy(_ => _.CustomerId).ToList();
            }
        }

        public static List<Customer> SearchByName(string contact)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Customers.Where(_ => _.ContactName.Contains(contact)).OrderBy(_ => _.CustomerId).ToList();
            }
        }
    }
}
