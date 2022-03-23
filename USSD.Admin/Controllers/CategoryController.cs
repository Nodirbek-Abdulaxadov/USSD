using Microsoft.AspNetCore.Mvc;

namespace USSD.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
