using MediatR;
using SocialMedia.API.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Posts.Command
{
    public class CommentPostCommand : IRequest<CommentDto>
    {
        public string PostId { get; set; }
        public string Comment { get; set; }
    }
}
