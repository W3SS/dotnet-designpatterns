using MvcDesignPattern.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MvcDesignPattern.Models
{
    [Table("WebsiteMetadata")]
    public class WebsiteMetadata
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(40)]
        public string DefaultTheme { get; set; }
        [Required]
        [StringLength(50)]
        public string AdminEmail { get; set; }
        [Required]
        public bool LogErrors { get; set; }

        private static WebsiteMetadata _instance;

        private WebsiteMetadata()
        {

        }

        public static WebsiteMetadata GetInstance()
        {
            if (_instance == null)
            {
                using (AppDbContext db = new AppDbContext())
                {
                    if (db.Metadata.Count() == 0)
                    {
                        db.Metadata.Add(new WebsiteMetadata()
                        {
                            Title = "My application",
                            AdminEmail = "admin@localhost",
                            DefaultTheme = "Summer",
                            LogErrors = true
                        });
                        db.SaveChanges();
                    }
                    _instance = db.Metadata.SingleOrDefault();
                }
            }
            return _instance;
        }
    }
}
