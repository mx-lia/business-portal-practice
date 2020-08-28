using Application.FunctionApi.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class FunctionController : BaseController
    {

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            GetFunctionsRequest request = new GetFunctionsRequest();
            var result = await Mediator.Send(request);

            return Ok(result);
        }
    }
}
