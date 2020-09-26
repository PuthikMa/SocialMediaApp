using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMedia.API.Domain.Models;
using SocialMedia.API.Infrastructure.Security.Interface;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Posts.Command
{
    public class EmotionPostCommandHandler : IRequestHandler<EmotionPostCommand, EmotionPostCount>
    {
        private readonly IUserAccessor userAccessor;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public EmotionPostCommandHandler(IUserAccessor userAccessor, DataContext context, IMapper mapper)
        {
            this.userAccessor = userAccessor;
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<EmotionPostCount> Handle(EmotionPostCommand request, CancellationToken cancellationToken)
        {
            var userId = userAccessor.GetCurrentUser();
            var result = await context.PostEmotions.Where(x => x.PostId.ToString() == request.PostId && x.UserId == userId).FirstOrDefaultAsync();
            if(result == null)
            {
                // add post emotion status 
                var postEmotion = new PostEmotion()
                {
                    CreateDateTime = DateTime.UtcNow,
                    EmotionTypeId = request.EmotionTypeId,
                    PostId = Guid.Parse(request.PostId),
                    UserId = userId
                };
                context.PostEmotions.Add(postEmotion);

            }
            else
            {
                if(result.EmotionTypeId == result.EmotionTypeId)
                {
                    // mean the user want to remove the status
                    context.PostEmotions.Remove(result);
                }
                else
                {
                    result.EmotionTypeId = result.EmotionTypeId;
                    context.PostEmotions.Update(result);
                }
            }

            await context.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
