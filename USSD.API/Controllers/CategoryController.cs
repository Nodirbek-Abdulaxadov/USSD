using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
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
            var contacts = await _service.GetCategoriesJson();
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var contacts = await _service.GetCategories();
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }

        [HttpGet, Route("get/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var contacts = await _service.GetCategory(id);
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }
    }
}
