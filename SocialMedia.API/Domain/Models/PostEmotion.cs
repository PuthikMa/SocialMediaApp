using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Models
{
    public class PostEmotion
    {
        public Guid Id { get; set; }
        public int EmotionTypeId { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public virtual AppUser User { get; set; }
        public virtual Post Post { get; set; }
        public virtual EmotionTypes EmotionTypes { get; set; }
    }
}
