using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using USSD.Admin.ViewModels;
using USSD.Data.Models;
using USSD.Data.Services;

namespace USSD.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IOperatorService _operatorService;

        public CategoryController(ICategoryService categoryService,
                                   IOperatorService operatorService)
        {
            _categoryService = categoryService;
            _operatorService = operatorService;
        }
        public async  Task<IActionResult> Index()
        {
            var item = await _categoryService.GetCategories();
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            foreach (var category in item)
            {
                Operator @operator = await _operatorService.GetOperatorName(category.OperatorId);
                CategoryViewModel categoryView = new CategoryViewModel()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Operator = @operator
                };
                categories.Add(categoryView);
            }
            return View(categories);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            CategoryAddViewModel viewModel = new CategoryAddViewModel()
            {
                operators = await _operatorService.GetOperators()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel viewModel)
        {
            await _categoryService.AddCategory(viewModel.category);
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
