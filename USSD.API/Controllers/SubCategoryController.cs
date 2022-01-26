using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using USSD.API.ApiModels;
using USSD.Data.Services;

namespace USSD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _service;

        public SubCategoryController(ISubCategoryService service)
        {
            _service = service;
        }

        [HttpGet, Route("getall/json")]
        public async Task<IActionResult> GetAllJsonAsync()
        {
            try
            {
                var categories = await _service.GetSubCategoriesJson();
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Subkategoriyalar ro'yxati",
                    Data = categories
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.InternalServerError,
                    Messages = ex.Message.ToString(),
                    Data = ""
                };

                return NotFound(res);
            }
        }

        [HttpGet, Route("getall/{categoryId}")]
        public async Task<IActionResult> GetAllByCategoryIdAsync(int categoryId)
        {
            try
            {
                var categories = await _service.GetAllByCategoryId(categoryId);
                List<SubCategoryModel> list = new List<SubCategoryModel>();
                foreach (var o in categories)
                {
                    SubCategoryModel subcategoryModel = new SubCategoryModel()
                    {
                        Id = o.Id,
                        SubCategoryName = o.SubCategoryName,
                        CategoryId = o.CategoryId
                    };
                    list.Add(subcategoryModel);
                }
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Tanlangan kategoriyaga tegishli barcha subKategoriyalar ro'yxati",
                    Data = list
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.InternalServerError,
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
                var categories = await _service.GetSubCategories();
                List<SubCategoryModel> list = new List<SubCategoryModel>();
                foreach (var o in categories)
                {
                    SubCategoryModel subcategoryModel = new SubCategoryModel()
                    {
                        Id = o.Id,
                        SubCategoryName = o.SubCategoryName,
                        CategoryId = o.CategoryId
                    };
                    list.Add(subcategoryModel);
                }
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "SubKategoriyalar ro'yxati",
                    Data = list
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.InternalServerError,
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
                var categories = await _service.GetSubCategory(id);
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Tanlangan Subkategoriya",
                    Data = categories
                };

                return Ok(res);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    Success = false,
                    Error_code = HttpStatusCode.InternalServerError,
                    Messages = ex.Message.ToString(),
                    Data = ""
                };

                return NotFound(res);
            }
        }
    }
}
