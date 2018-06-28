using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDesignPattern.Models
{
    [Table("ComputerParts")]
    public class ComputerPart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string UseType { get; set; }
        [Required]
        [StringLength(20)]
        public string Part { get; set; }
        [Required]
        [StringLength(50)]
        public string PartCode { get; set; }
    }
}
