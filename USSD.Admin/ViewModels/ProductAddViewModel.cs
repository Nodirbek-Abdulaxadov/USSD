using System.Collections.Generic;
using USSD.Data.Models;

namespace USSD.Admin.ViewModels
{
    public class ProductAddViewModel
    {
       public Product product { get; set; }
       public List<SubCategory> subCategories { get; set; } 
    }
}
