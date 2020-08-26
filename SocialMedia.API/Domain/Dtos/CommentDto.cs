using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Dtos
{
    public class CommentDto
    {
        public string Id { get; set; }
        public string CommentContent { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public virtual AppUserDto User { get; set; }
    }
}
