using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.ForgotPassword.Commands;

namespace API.Controllers
{
    public class PasswordRecoveryController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
        {
            try
            {
                await Mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                Response.StatusCode = 502;
                return new JsonResult(message);
            }

        }
   
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            try
            { 
                await Mediator.Send(command);

                return Ok();
            }
            catch (Exception ex)
            {
                var message = new
                {
                    message = ex.Message
                };
                Response.StatusCode = 403;
                return new JsonResult(message);
            }

        }
    }
}