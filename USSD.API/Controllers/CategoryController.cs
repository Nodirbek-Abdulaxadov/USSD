using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using USSD.API.ApiModels;
using USSD.Data.Models;
using USSD.Data.Services;

namespace USSD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet, Route("getall/json")]
        public async Task<IActionResult> GetAllJsonAsync()
        {
            try
            {
                var categories = await _service.GetCategoriesJson();
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Kategoriyalar ro'yxati",
                    Data = categories
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.NotFound,
                    Messages = ex.Message.ToString(),
                    Data = ""
                };

                return NotFound(res);
            }
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var categories = await _service.GetCategories();
                List<CategoryModel> list = new List<CategoryModel>();
                foreach (var o in categories)
                {
                    CategoryModel categoryModel = new CategoryModel()
                    {
                        Id = o.Id,
                        CategoryName = o.CategoryName,
                        OperatorId = o.OperatorId
                    };
                    list.Add(categoryModel);
                }
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Kategoriyalar ro'yxati",
                    Data = list
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.NotFound,
                    Messages = ex.Message.ToString(),
                    Data = ""
                };

                return NotFound(res);
            }
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var category = await _service.GetCategory(id);
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Tanlangan kategoriya",
                    Data = category
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.NotFound,
                    Messages = ex.Message.ToString(),
                    Data = ""
                };

                return NotFound(res);
            }
        }
    }
}
