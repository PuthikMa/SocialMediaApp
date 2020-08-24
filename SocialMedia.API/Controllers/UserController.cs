using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Application.Logic.Users.Command;
using SocialMedia.API.Application.Logic.Users.Query;
using SocialMedia.API.Domain.Models;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginQuery loginQuery)
        {
          
            return await mediator.Send(loginQuery);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterCommand  registerCommand)
        {
           
            return await mediator.Send(registerCommand);
        }
        [HttpGet("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string Email)
        {
            var Token = await mediator.Send(new ForgetPasswordQuery { Email = Email });
           
            return Ok(Token);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPassword resetPassword)
        {
            var i = Url.Action();
            await mediator.Send(new ResetPasswordCommand { ResetPassword = resetPassword });

            return Ok();
        }

    }
}
