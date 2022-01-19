using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USSD.Data.Models
{
    [Table("product")]
    public class Product
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string TitleUz { get; set; }

        [Required]
        [MaxLength(20)]
        public string TitleRu { get; set; }

        [Required]
        [MaxLength(20)]
        public string DescriptionUz { get; set; }

        [Required]
        [MaxLength(20)]
        public string DescriptionRu { get; set; }

        [Required]
        [MaxLength(20)]
        public string ExpiryDate { get; set; }

        [Required]
        public int Valume { get; set; }

        [Required]
        [MaxLength(20)]
        public string Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        public int SubCategoryId { get; set; }
    }
}