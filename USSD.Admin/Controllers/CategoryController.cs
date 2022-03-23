using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using USSD.Data.Models;
using USSD.Data.Services;

namespace USSD.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async  Task<IActionResult> Index()
        {
            var item = await _categoryService.GetCategories();
            return View(item);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _categoryService.GetCategory(id);
            return View(item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var item = await _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
