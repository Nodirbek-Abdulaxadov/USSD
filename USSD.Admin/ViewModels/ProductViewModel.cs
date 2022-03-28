using System.ComponentModel.DataAnnotations;
using USSD.Data.Models;

namespace USSD.Admin.ViewModels
{
    public class ProductViewModel
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TitleUz { get; set; }

        [Required]
        [MaxLength(100)]
        public string TitleRu { get; set; }

        [Required]
        [MaxLength(5000)]
        public string DescriptionUz { get; set; }

        [Required]
        [MaxLength(5000)]
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

        public SubCategory subCategory { get; set; }
    }
}
