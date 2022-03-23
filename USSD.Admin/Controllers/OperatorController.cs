using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using USSD.Data.Models;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Operator newOperator)
        {
            await _operatorService.AddOperator(newOperator);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Operator @operator = await _operatorService.GetOperator(id);
            return View(@operator);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Operator @operator)
        {
            await _operatorService.UpdateOperator(@operator);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _operatorService.DeleteOperator(id);
            return RedirectToAction("Index");
        }
    }
}
