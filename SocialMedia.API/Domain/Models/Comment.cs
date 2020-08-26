using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
