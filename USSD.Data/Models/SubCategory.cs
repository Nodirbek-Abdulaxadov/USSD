using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USSD.Data.Models
{
    [Table("subcategory")]
    public class SubCategory
    {
        [Required, Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string SubCategoryName { get; set; }

        public int CategoryId { get; set; }

        public List<Product> Products { get; set; }
    }
}