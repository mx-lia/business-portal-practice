using System.Threading.Tasks;
using Application.UsersApi.Commands;
using Application.UsersApi.Requests;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ITokenService _tokenService;

        public UsersController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> FindOneById([FromRoute] int? id)
        {
            try
            {
                GetUserByIdRequest request = new GetUserByIdRequest() { Id = id };
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> FindByPage([FromQuery] GetByPageRequest request)
        {
            try
            {
                var result = await Mediator.Send(request);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            try
            {
                var created = await Mediator.Send(command);
                return Ok(created);
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            try
            {
                DeleteUserCommand command = new DeleteUserCommand() { Id = id };
                await Mediator.Send(command);

                return Ok();
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            try
            {
                var edited = await Mediator.Send(command);
                return Ok(edited);
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