using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Models
{
    public class EmotionTypes
    {
        public int Id { get; set; }
        public string EmotionDetail { get; set; }
        public virtual PostEmotion PostEmotion { get; set; }
    }
}
