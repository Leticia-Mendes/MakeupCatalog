using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.MakeupCatalog
{
    [Table("MakeupType")]
    public class MakeupType
    {
        public MakeupType()
        {
            Products = new Collection<Product>();
        }

        [Key]
        public int MakeupTypeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, ErrorMessage = "Name must be between 2 and 80 character", MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}