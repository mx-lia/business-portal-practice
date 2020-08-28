using System.Threading.Tasks;
using Application.RegionApi.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RegionController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            GetRegionsRequest request = new GetRegionsRequest();
            var result = await Mediator.Send(request);

            return Ok(result);
        }
    }


    
}
    


