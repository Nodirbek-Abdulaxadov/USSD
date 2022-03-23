using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using USSD.Data.Services;

namespace USSD.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _productService.GetProducts();
            return View(item);
        }
    }
}
