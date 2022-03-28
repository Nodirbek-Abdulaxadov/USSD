using System.ComponentModel.DataAnnotations;
using USSD.Data.Models;

namespace USSD.Admin.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string CategoryName { get; set; }

        public Operator Operator { get; set; }
    }
}
