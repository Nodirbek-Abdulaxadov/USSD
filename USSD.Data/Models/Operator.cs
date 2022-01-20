using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USSD.Data.Models
{
    [Table("operator")]
    public class Operator
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string OpeatorName { get; set; }

        public List<Category> Categories { get; set; }
    }
}
