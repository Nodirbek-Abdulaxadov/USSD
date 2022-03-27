using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpGet, Route("getall/{subCategoryId}")]
        public async Task<IActionResult> GetAllBySCIdAsync(int subCategoryId)
        {
            try
            {
                var contacts = await _service.GetProductsBySubCategory(subCategoryId);
                var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var contacts = await _service.GetProducts();
                var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                string uplodFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                string uniqueName = "Product.json";
                string filePath = Path.Combine(uplodFolder, uniqueName);
                System.IO.File.WriteAllText(filePath, json);

                Stream stream = System.IO.File.OpenRead(filePath);

                return File(stream, "application/octet-stream", "Product.json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                Product contacts = await _service.GetProduct(id);
                List<Product> products = new List<Product>();
                products.Add(contacts);
                var json = JsonConvert.SerializeObject(products, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                return Ok(json);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
