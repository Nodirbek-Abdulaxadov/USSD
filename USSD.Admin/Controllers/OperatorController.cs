using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using USSD.Data.Services;

namespace USSD.Admin.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IOperatorService _operatorService;

        public OperatorController(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        public async Task<IActionResult> Index()
        {
            var listOperators = await _operatorService.GetOperators();
            return View(listOperators);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
