using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using USSD.Admin.ViewModels;
using USSD.Data.Models;
using USSD.Data.Services;

namespace USSD.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISubCategoryService _subCategoryService;

        public ProductController(IProductService productService,
            ISubCategoryService subCategoryService) 
        {
            _productService = productService;
            _subCategoryService = subCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _productService.GetProducts();
            List<ProductViewModel> productViewModel = new List<ProductViewModel>();
            foreach (var product in item)
            {
                SubCategory subCategory = await _subCategoryService.GetSubCategoryNoList(product.SubCategoryId);
                ProductViewModel newViewmodel = new ProductViewModel()
                {
                    Id = product.Id,
                    TitleUz = product.TitleUz,
                    TitleRu = product.TitleRu,
                    DescriptionUz = product.DescriptionUz,
                    DescriptionRu = product.DescriptionRu,
                    ExpiryDate = product.ExpiryDate,
                    Valume = product.Valume,
                    Price = product.Price,
                    Code = product.Code,
                    subCategory = subCategory
                };
                productViewModel.Add(newViewmodel);
            }
            return View(productViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ProductAddViewModel productViewModel = new ProductAddViewModel()
            {
                subCategories = await _subCategoryService.GetSubCategories()
            };
            return View(productViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel productViewModel)
        {
            await _productService.AddProduct(productViewModel.product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ViewMore()
        {
          
        }
        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}