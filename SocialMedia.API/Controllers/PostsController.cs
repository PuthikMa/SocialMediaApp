
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Application.Logic.Posts.Command;
using SocialMedia.API.Application.Logic.Posts.Query;
using SocialMedia.API.Domain.Dtos;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IMediator mediator;
        public PostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostCommand createPost)
        {
            return Ok(await mediator.Send(createPost)) ;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetPost()
        {

            var Posts = await mediator.Send(new GetPostsQuery());
            return Posts;
        }
    }
}
