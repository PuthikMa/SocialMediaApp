using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.API.Domain.Dtos;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Posts.Query
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public GetPostsQueryHandler(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = 
                await context.Posts
                .Include(x => x.Comments)
                .Include(x => x.User)
                .ToListAsync();

            var postsDto = mapper.Map<List<PostDto>>(posts);

            return postsDto;

            throw new NotImplementedException();
        }
    }
}
