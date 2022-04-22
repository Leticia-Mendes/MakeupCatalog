using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.MakeupCatalog
{
    [Table("MakeupType")]
    public class MakeupType
    {
        [Key]
        public int MakeupTypeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, ErrorMessage = "Name must be between 2 and 80 character", MinimumLength = 2)]
        public string Name { get; set; }

        public List<Product> Product { get; set; }

        public MakeupType()
        {
            Product = new List<Product>();
        }
    }
}