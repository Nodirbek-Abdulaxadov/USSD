using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
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
                var operators = await _mixedService.GetCategories(operatorId, categoryId);

                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Operator bo'yicha tanlangan kategoriyalar",
                    Data = operators
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
