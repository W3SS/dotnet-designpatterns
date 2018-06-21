using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Core
{
    [Table("Customers")]
    public class Customer
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
    }
}
