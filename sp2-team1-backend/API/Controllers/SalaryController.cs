using System.IO;
using System.Threading.Tasks;
using Application.SalaryApi.Commands;
using Application.SalaryApi.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API.Controllers
{
    public class SalaryController : BaseController
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public SalaryController(IWebHostEnvironment webHost)
        {
            _appEnvironment = webHost;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Calculate([FromBody] CalculateSalaryCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return Ok(result);
            }
            catch(Exception ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                Response.StatusCode = 400;
                return new JsonResult(message);
            }           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetSalaryByRegionAndFuncRequest request)
        {
            try
            {
                var result = await Mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                Response.StatusCode = 400;
                return new JsonResult(message);
            }           
        }

        [HttpPost("GetPdfFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPdfFile([FromBody] GetPdfFileCommand command)
        {
            try
            {
                await Mediator.Send(command);
                string file_path = Path.Combine(_appEnvironment.ContentRootPath, "result.pdf");
                string file_type = "application/pdf";
                string file_name = "result.pdf";

                byte[] mas = System.IO.File.ReadAllBytes(file_path);

                return File(mas, file_type, file_name);
            }
            catch (Exception ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                Response.StatusCode = 400;
                return new JsonResult(message);
            }

            
        }
    }
}
