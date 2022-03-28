using System.ComponentModel.DataAnnotations;

namespace USSD.Data.Models
{
    public class CheckModel
    {
        [Key]
        public int Id { get; set; }
        public int DatabaseVersion { get; set; }
        public string LastUpdated { get; set; }
    }
}
