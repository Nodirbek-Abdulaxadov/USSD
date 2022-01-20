using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
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
            try
            {
                var operators = await _service.GetOperatorsJson();                

                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Barcha operatorlar ro'yxati batafsil",
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

        [HttpGet, Route("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var operators = await _service.GetOperators();
                List<OperatorModel> list = new List<OperatorModel>();
                foreach (var o in operators)
                {
                    OperatorModel operatorModel = new OperatorModel()
                    {
                        Id = o.Id,
                        OpeatorName = o.OpeatorName
                    };
                    list.Add(operatorModel);
                }
                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Operatorlar ro'yxati",
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
                var operatr = await _service.GetOperator(id);

                var res = new
                {
                    Success = true,
                    StatusCode = HttpStatusCode.OK,
                    Messages = "Tanlangan operator",
                    Data = operatr
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
