using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Application.Logic.Users.Query;
using SocialMedia.API.Domain.Models;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ValuesController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpGet("GetValue")]
        public async Task<ActionResult<User>> Login()
        {

            return Ok("I love it");
        }
    }
}
