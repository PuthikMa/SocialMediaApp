using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Dtos
{
    public class PostDto
    {
        public string Id { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }
        public string CreateDate { get; set; }
        public int LikeCount { get; set; }
        public int AngeryCount { get; set; }
        public virtual AppUserDto User { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
        public virtual ICollection<PostEmotionDto> PostEmotions { get; set; }
    }
}
