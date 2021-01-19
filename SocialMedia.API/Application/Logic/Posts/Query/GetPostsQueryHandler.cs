using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.API.Domain.Dtos;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .Include(x => x.Comments).ThenInclude(a=>a.User)
                .Include(x => x.User).ThenInclude(x => x.Photo)
                .Include(x => x.PostEmotions)
                .OrderByDescending(x=> x.CreateDate)
                .ToListAsync();

            var postsDto = mapper.Map<List<PostDto>>(posts);

            foreach(var postdto in postsDto)
            {
                postdto.LikeCount = postdto.PostEmotions.Count(x => x.EmotionTypeId == 1);
                postdto.AngeryCount = postdto.PostEmotions.Count(x => x.EmotionTypeId == 2);
            }

            return postsDto;

            throw new NotImplementedException();
        }
    }
}
