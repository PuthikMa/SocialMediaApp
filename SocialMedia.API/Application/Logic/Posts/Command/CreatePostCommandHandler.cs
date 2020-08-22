

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.API.Domain.Dtos;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;
using SocialMedia.API.Infrastructure.Security.Interface;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Posts.Command
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IUserAccessor userAccessor;
        private readonly UserManager<AppUser> userManager;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CreatePostCommandHandler(IUserAccessor userAccessor, UserManager<AppUser> userManager, DataContext context, IMapper mapper)
        {
            this.userAccessor = userAccessor;
            this.userManager = userManager;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var userName = userAccessor.GetCurrentUser();

            var user = await userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var post = new Post
                {
                    PostContent = request.Post,
                    UserId = user.Id
                };

                context.Posts.Add(post);
                await context.SaveChangesAsync();


                var postDto = mapper.Map<PostDto>(post);
                return postDto;

            }



            throw new NotImplementedException();
        }
    }
}
