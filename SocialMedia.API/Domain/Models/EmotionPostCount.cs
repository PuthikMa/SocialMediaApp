using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Models
{
    public class EmotionPostCount
    {
        public string PostId { get; set; }
        public int LikeCount { get; set; }
        public int AngryCount { get; set; }
    }
}
