using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocialMedia.API.Application.Hubs;
using SocialMedia.API.Domain.Dtos;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;
using SocialMedia.API.Infrastructure.Security.Interface;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Posts.Command
{
    public class CommentPostCommandHandler : IRequestHandler<CommentPostCommand, CommentDto>
    {
        private readonly IUserAccessor userAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly DataContext context;
        private readonly IMapper mapper;
        private readonly IHubContext<CommentHub> hub;

        public CommentPostCommandHandler(IUserAccessor userAccessor, UserManager<AppUser> userManager, DataContext context, IMapper mapper, IHubContext<CommentHub> hub)
        {
            this.userAccessor = userAccessor;
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
            this.hub = hub;
        }
        public async Task<CommentDto> Handle(CommentPostCommand request, CancellationToken cancellationToken)
        {
            var userName = userAccessor.GetCurrentUser();

            var user = await context.Users.Where(x => x.UserName == userName).Include(x => x.Photo).FirstOrDefaultAsync();

            var post = await context.Posts.Where(x => x.Id == Guid.Parse(request.PostId)).FirstOrDefaultAsync();
            if (user != null && post!=null)
            {
                var comment = new Comment
                {
                    PostId = post.Id,
                    CommentContent = request.Comment,
                    UserId = user.Id,
                    CreateDate = DateTime.UtcNow
                };

                context.Comments.Add(comment);
                var result = await context.SaveChangesAsync()>0;
                if (result)
                {
                    var commentDto = mapper.Map<CommentDto>(comment);
                    var json = JsonConvert.SerializeObject(commentDto);
                    await hub.Clients.All.SendAsync("ReceiveComment",json);
                    return commentDto;
                }
            }

            throw new NotImplementedException();
        }
    }
}
