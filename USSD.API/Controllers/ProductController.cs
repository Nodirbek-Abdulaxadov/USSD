using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var contacts = await _service.GetProducts();
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
            //StatusCode(200, json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var contacts = await _service.GetProduct(id);
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }
    }
}
