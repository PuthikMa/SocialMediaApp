using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Dtos
{
    public class PostEmotionDto
    {
        public Guid Id { get; set; }
        public int EmotionTypeId { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
