using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Core
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WebsiteMetadata> Metadata { get; set; }
        public DbSet<ComputerPart> ComputerParts { get; set; }
    }
}
