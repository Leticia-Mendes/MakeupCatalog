using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.MakeupCatalog
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, ErrorMessage = "Name must be between 2 and 80 character", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Color is required")]
        [MaxLength(40, ErrorMessage = "Color must be max length 40 character")]
        public string Color { get; set; }

        [MaxLength(40, ErrorMessage = "Color must be max length 40 character")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [MaxLength(600, ErrorMessage = "Description must be max length 600 character")]
        public string Description { get; set; }

        public MakeupType MakeupType { get; set; }

        public int MakeupTypeId { get; set; }
    }
}