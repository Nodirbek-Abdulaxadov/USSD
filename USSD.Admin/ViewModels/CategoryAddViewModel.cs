using System.Collections.Generic;
using USSD.Data.Models;

namespace USSD.Admin.ViewModels
{
    public class CategoryAddViewModel
    {
        public Category category { get; set; }
        public List<Operator> operators { get; set; }
    }
}
