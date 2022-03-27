using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _service;
        private readonly IWebHostEnvironment _environment;

        public OperatorController(IOperatorService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;
        }

        [HttpGet, Route("checkupdate")]
        public async Task<IActionResult> Check()
        {
            try
            {
                List<CheckModel> updates = await _service.GetCheckUpdates();
                
                var json = JsonConvert.SerializeObject(updates, Formatting.Indented,
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

        [HttpGet, Route("getall/json")]
        public async Task<IActionResult> GetAllJsonAsync()
        {
            try
            {
                var contacts = await _service.GetOperatorsJson();
                var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                string uplodFolder = Path.Combine(_environment.WebRootPath, "Uploads");
                string uniqueName = "All.json";
                string filePath = Path.Combine(uplodFolder, uniqueName);
                System.IO.File.WriteAllText(filePath, json);

                Stream stream = System.IO.File.OpenRead(filePath);

                return File(stream, "application/octet-stream", "All.json");
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
                //var contacts = await _service.GetOperators();
                //var json = JsonConvert.SerializeObject(contacts, Formatting.Indented,
                //    new JsonSerializerSettings
                //    {
                //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                //    });
                var contacts = await _service.GetOperatorsJson();
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
                Operator contacts = await _service.GetOperator(id);
                List<Operator> operators = new List<Operator>();
                operators.Add(contacts);
                var json = JsonConvert.SerializeObject(operators, Formatting.Indented,
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
