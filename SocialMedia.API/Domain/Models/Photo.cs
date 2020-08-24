using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public virtual AppUser User { get; set; }


    }
}
