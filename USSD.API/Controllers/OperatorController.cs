using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using USSD.Data.Models;
using USSD.Data.Services;

namespace USSD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _service;

        public OperatorController(IOperatorService service)
        {
            _service = service;
        }

        [HttpGet, Route("getall/json")]
        public async Task<IActionResult> GetAllJsonAsync()
        {
            var contacts = await _service.GetOperatorsJson();
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
            //StatusCode(200, json);
        }

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var contacts = await _service.GetOperators();
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
            var contacts = await _service.GetOperator(id);
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }
    }
}
