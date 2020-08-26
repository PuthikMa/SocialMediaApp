using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string PostContent { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
