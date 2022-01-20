using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using USSD.Data.Models;
using USSD.Data.Services;

namespace USSD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var categories = await _service.GetProducts();
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Barcha productlar ro'yxati",
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

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var categories = await _service.GetProduct(id);
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Tanlangan product",
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
    }
}
