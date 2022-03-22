using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using USSD.Data.Services;

namespace USSD.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class MixedController : ControllerBase
    {
        private readonly IMixedService _mixedService; 

        public MixedController(IMixedService mixedService)
        {
            _mixedService = mixedService;
        }

        [HttpGet, Route("getbyId")]
        public async Task<IActionResult> GetById(int operatorId, int categoryId)
        {
            try
            {
                var contacts = await _mixedService.GetCategories(operatorId, categoryId);
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
    }
}
