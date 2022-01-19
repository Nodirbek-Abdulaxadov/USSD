using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USSD.Data.Models
{
    [Table("category")]
    public class Category
    {
        [Required, Key]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string CategoryName { get; set; }

        public int OperatorId { get; set; }

        public List<SubCategory> SubCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}
