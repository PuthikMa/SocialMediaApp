using MediatR;
using SocialMedia.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Posts.Command
{
    public class EmotionPostCommand : IRequest<EmotionPostCount>
    {
        public string PostId { get; set; }
        public int EmotionTypeId { get; set; }
    }
}
