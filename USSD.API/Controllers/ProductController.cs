﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

                return Ok(json);
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
